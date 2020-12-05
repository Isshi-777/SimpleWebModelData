using Newtonsoft.Json;
using UnityEngine;
using System.Collections;

/// <summary>
/// マスターデータの挙動テスト
/// </summary>
public class MasterDataScene : MonoBehaviour
{
    private IEnumerator Start()
    {
        // アイテムマスターデータ
        MasterDataTable_Item itemTable = new MasterDataTable_Item();
        MasterDataTable_Item itemtTable2 = null;
        yield return SampleApiManager.GetInstance().ConnectApi(itemTable.TableName,
            (json) =>
            {
                itemTable.UpdateDataList(json);
                itemtTable2 = JsonConvert.DeserializeObject<MasterDataTable_Item>(json);
            });


        // クエストマスターデータ
        MasterDataTable_Quest questTable = new MasterDataTable_Quest();
        MasterDataTable_Quest questTable2 = null;
        yield return SampleApiManager.GetInstance().ConnectApi(questTable.TableName,
           (json) =>
           {
               questTable.UpdateDataList(json);
               questTable2 = JsonConvert.DeserializeObject<MasterDataTable_Quest>(json);
           });

        // 簡単なクエストのみ取得
        var easyQuestList = questTable.GetEasyQuestList();

        Debug.Log("complete !!!");
    }
}
