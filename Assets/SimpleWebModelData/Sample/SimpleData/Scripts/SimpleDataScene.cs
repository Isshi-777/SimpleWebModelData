﻿using Newtonsoft.Json;
using System.Collections;
using UnityEngine;

/// <summary>
/// 単純なデータの挙動テスト
/// </summary>
public class SimpleDataScene : MonoBehaviour
{
    private IEnumerator Start()
    {
        // テストデータ
        SimpleData_Test testData = null;
        yield return SampleApiManager.GetInstance().ConnectApi("TestJson",
            (json) =>
            {
                testData = JsonConvert.DeserializeObject<SimpleData_Test>(json);
            });

        Debug.Log("Serialize TestData");
        Debug.Log(JsonConvert.SerializeObject(testData));
        Debug.Log(testData.ToJson());


        // ユーザーデータ
        SimpleData_User userData = null;
        yield return SampleApiManager.GetInstance().ConnectApi("UserJson",
            (json) =>
            {
                userData = JsonConvert.DeserializeObject<SimpleData_User>(json);
            });

        Debug.Log("Serialize UserData");
        Debug.Log(JsonConvert.SerializeObject(userData));
        Debug.Log(userData.ToJson());

        // アイテムデータ
        SimpleData_Item itemData = null;
        yield return SampleApiManager.GetInstance().ConnectApi("ItemJson",
            (json) =>
            {
                itemData = JsonConvert.DeserializeObject<SimpleData_Item>(json);
            });

        Debug.Log("Serialize ItemData");
        Debug.Log(JsonConvert.SerializeObject(itemData));
        Debug.Log(itemData.ToJson());

        Debug.Log("complete !!!");
    }
}
