using Newtonsoft.Json;
using System.Collections;
using UnityEngine;

/// <summary>
/// マスターデータの挙動テスト
/// </summary>
public class MasterDataScene : MonoBehaviour
{
    private IEnumerator Start()
    {
        // アイテムマスターデータ
        MasterDataTable_Item itemTable = new MasterDataTable_Item();
        MasterDataTable_Item itemTable2 = null;
        yield return SampleApiManager.GetInstance().ConnectApi(itemTable.TableName,
            (json) =>
            {
                itemTable.UpdateDataList(json);
                itemTable2 = JsonConvert.DeserializeObject<MasterDataTable_Item>(json);
            });

        Debug.Log("Serialize ItemTable");
        Debug.Log(JsonConvert.SerializeObject(itemTable));
        Debug.Log(itemTable.ToJson());
        Debug.Log(JsonConvert.SerializeObject(itemTable2));
        Debug.Log(itemTable2.ToJson());


        // クエストマスターデータ
        MasterDataTable_Quest questTable = new MasterDataTable_Quest();
        MasterDataTable_Quest questTable2 = null;
        yield return SampleApiManager.GetInstance().ConnectApi(questTable.TableName,
           (json) =>
           {
               questTable.UpdateDataList(json);
               questTable2 = JsonConvert.DeserializeObject<MasterDataTable_Quest>(json);
           });

        Debug.Log("Serialize QuestTable");
        Debug.Log(JsonConvert.SerializeObject(questTable));
        Debug.Log(questTable.ToJson());
        Debug.Log(JsonConvert.SerializeObject(questTable2));
        Debug.Log(questTable2.ToJson());

        // 簡単なクエストのみ取得
        var easyQuestList = questTable.GetEasyQuestList();

        Debug.Log("complete !!!");
    }
}
