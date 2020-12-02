using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// 単純なデータの挙動テスト
/// </summary>
public class SimpleDataScene : MonoBehaviour
{
    private void Start()
    {
        // ユーザーデータ
        TextAsset userJson = Resources.Load<TextAsset>("SimpleData/UserJson");
        SimpleData_User userData = JsonConvert.DeserializeObject<SimpleData_User>(userJson.text);

        // アイテムデータ
        TextAsset itemJson = Resources.Load<TextAsset>("SimpleData/ItemJson");
        SimpleData_Item itemData = JsonConvert.DeserializeObject<SimpleData_Item>(itemJson.text);

        Debug.Log(userData + " : " + itemData);
    }
}
