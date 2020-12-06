using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データリストのコンテナの基底クラス
/// ※継承してプロパティは増やせるが、基本的にマスターデータなど１つの配列のみを管理するクラスの基底クラス
/// 　(継承により増やしたJsonPropertyの値のクラス内での更新処理は自前で書く必要あり)
/// </summary>
/// <typeparam name="T">AWebModelData</typeparam>
public abstract class AWebModelDataListContainer<T> : AJsonModelData where T : AWebModelData
{
    /// <summary>
    /// データリスト
    /// </summary>
    [JsonProperty("data")]
    protected List<T> dataList = new List<T>();

    /// <summary>
    /// 識別のKey
    /// </summary>
    [JsonIgnore]
    public abstract WebModelDataConstants.EDataIdentificationKey IdentificationKey { get; }

    /// <summary>
    /// 識別名
    /// </summary>
    [JsonIgnore]
    public string IdentificationName => WebModelDataConstants.GetIndifinitionName(this.IdentificationKey);

    /// <summary>
    /// Jsonによるデータリストの更新 (「dataList」変数の更新のみ)
    /// </summary>
    /// <param name="json">Jsonデータ</param>
    public void UpdateDataList(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError(" Json is null or empty !!! ");
            return;
        }

        // JsonPropertyが「仕組み上増やせる」のでDictionary<string, List<T>>へのデシリアライズではなくJObjectを使用
        JToken token;
        JObject jo = JObject.Parse(json);
        if (jo != null && jo.TryGetValue("data", out token))
        {
            var list = token.ToObject<List<T>>();
            if (list != null)
            {
                if (list != null)
                {
                    foreach (var data in list)
                    {
                        this.UpdateData(data);
                    }
                }
            }
            else
            {
                Debug.LogWarning(" \"data\" value type is not " + typeof(List<T>));
            }
        }
        else
        {
            Debug.LogWarning(" \"data\" colummn is not found !!! \n" + json);
        }
    }

    /// <summary>
    /// データの追加（すでに同じPrimaryKeyのデータがあるときは入れ替え）
    /// </summary>
    /// <param name="data">データ</param>
    public void UpdateData(T data)
    {
        if (data == null)
        {
            Debug.LogError(" Data is null !!! ");
        }
        else
        {
            T lastData = this.dataList.Find(x => x.PrimaryKey == data.PrimaryKey);
            if (lastData != null)
            {
                // すでに同じPrimaryKeyのデータがあるときはそれを削除する
                this.RemoveData(lastData);
            }

            this.dataList.Add(data);
        }
    }

    /// <summary>
    /// データの削除
    /// </summary>
    /// <param name="data">データ</param>
    public void RemoveData(T data)
    {
        if (data == null)
        {
            Debug.LogError(" Data is null !!! ");
        }
        else
        {
            if (this.dataList.Exists(x => x.PrimaryKey == data.PrimaryKey))
            {
                this.dataList.Remove(data);
            }
            else
            {
                Debug.LogError(" Data is not found in DataList !!! => " + data.PrimaryKey);
            }
        }
    }

    /// <summary>
    /// データ全削除
    /// </summary>
    public void Clear()
    {
        this.dataList.Clear();
    }

    /// <summary>
    /// データリストのリフレッシュ（全部削除して、その後にJsonのデータを追加）
    /// </summary>
    /// <param name="json">Jsonテキスト</param>
    public void RefreshDataList(string json)
    {
        this.Clear();
        this.UpdateDataList(json);
    }

    /// <summary>
    /// PrimaryKeyが一致しているデータを返す
    /// </summary>
    /// <param name="primaryKey">PrimaryKey</param>
    /// <returns>データ</returns>
    public virtual T GetEntryData(string primaryKey)
    {
        if (string.IsNullOrEmpty(primaryKey))
        {
            Debug.LogError(" Primary key is null or enmpty !!! ");
            return null;
        }

        T data = this.dataList.Find(x => x.PrimaryKey == primaryKey);
        if (data == null)
        {
            Debug.LogError(" Not found data !!! => " + primaryKey);
        }

        return data;
    }

    /// <summary>
    /// Keyのリストから作成されるPrimaryKeyが一致しているデータを返す
    /// </summary>
    /// <param name="keys">PrimaryKey作成のためのKeyリスト</param>
    /// <returns>データ</returns>
    public virtual T GetEntryData(params string[] keys)
    {
        string primaryKey = WebModelDataHelper.GeneratePrimaryKey(keys);
        return this.GetEntryData(primaryKey);
    }
}
