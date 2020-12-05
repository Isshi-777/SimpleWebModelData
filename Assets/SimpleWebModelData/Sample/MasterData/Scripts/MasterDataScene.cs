using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// マスターデータの挙動テスト
/// </summary>
public class MasterDataScene : MonoBehaviour
{
    private void Start()
    {
        // アイテムマスターデータ
        MasterDataTable_Item itemTable = new MasterDataTable_Item();
        string url = "MasterData/" + itemTable.TableName;
        TextAsset json = Resources.Load<TextAsset>(url);

        MasterDataTable_Item itemtTable2 = JsonConvert.DeserializeObject<MasterDataTable_Item>(json.text);
        itemTable.UpdateDataList(json.text);

        // クエストマスターデータ
        MasterDataTable_Quest questTable = new MasterDataTable_Quest();
        string url2 = "MasterData/" + questTable.TableName;
        TextAsset json2 = Resources.Load<TextAsset>(url2);

        MasterDataTable_Quest questTable2 = JsonConvert.DeserializeObject<MasterDataTable_Quest>(json2.text);
        questTable.UpdateDataList(json2.text);

        // 簡単なクエストのみ取得
        var easyQuestList = questTable.GetEasyQuestList();

        Debug.Log("complete !!!");
    }
}
