using Newtonsoft.Json;
using UnityEngine;
using System.Collections;

/// <summary>
/// 単純なデータの挙動テスト
/// </summary>
public class SimpleDataScene : MonoBehaviour
{
    private IEnumerator Start()
    {
        // ユーザーデータ
        SimpleData_User userData = null;
        yield return SampleApiManager.GetInstance().ConnectApi("UserJson",
            (json) =>
            {
                userData = JsonConvert.DeserializeObject<SimpleData_User>(json);
            });

        // アイテムデータ
        SimpleData_Item itemData = null;
        yield return SampleApiManager.GetInstance().ConnectApi("ItemJson",
            (json) =>
            {
                itemData = JsonConvert.DeserializeObject<SimpleData_Item>(json);
            });

        Debug.Log("complete !!!");
    }
}
