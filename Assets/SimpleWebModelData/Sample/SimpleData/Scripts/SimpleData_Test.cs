using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// テスト用データ
/// </summary>
public class SimpleData_Test : AWebModelData
{
    /// <summary>
    /// int型の値
    /// </summary>
    [JsonProperty("intVal")]
    public int IntValue { private set; get; }

    /// <summary>
    /// long型の値
    /// </summary>
    [JsonProperty("longVal")]
    public long LongValue { private set; get; }

    /// <summary>
    /// float型の値
    /// </summary>
    [JsonProperty("floatVal")]
    public float FloatValue { private set; get; }

    /// <summary>
    /// bool型の値
    /// </summary>
    [JsonProperty("boolVal")]
    public bool BoolValue { private set; get; }

    /// <summary>
    /// string型の値
    /// </summary>
    [JsonProperty("stringVal")]
    public string StringValue { private set; get; }

    /// <summary>
    /// int型配列の値
    /// </summary>
    [JsonProperty("intArrayVal")]
    public int[] IntArrayValue { private set; get; }

    /// <summary>
    /// string型リストの値
    /// </summary>
    [JsonProperty("stringListVal")]
    public List<string> StringListValue { private set; get; }

    /// <summary>
    /// クラス型の値
    /// </summary>
    [JsonProperty("item")]
    public SimpleData_Item ItemData { private set; get; }

    /// <summary>
    /// Dictionary型の値
    /// </summary>
    [JsonProperty("itemDic")]
    public Dictionary<string, SimpleData_Item> ItemDicValue { private set; get; }

    public override string PrimaryKey => WebModelDataHelper.GeneratePrimaryKey(this.IntValue.ToString());
}
