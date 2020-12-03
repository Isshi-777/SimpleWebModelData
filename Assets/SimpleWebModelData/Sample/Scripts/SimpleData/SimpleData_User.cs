using Newtonsoft.Json;

/// <summary>
/// 単純なデータ「ユーザー情報」のデータ
/// </summary>
public class SimpleData_User : AWebModelData
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    [JsonProperty("id")]
    public long UserId { private set; get; }

    /// <summary>
    /// ユーザー名
    /// </summary>
    [JsonProperty("name")]
    public string UserName { private set; get; }

    /// <summary>
    /// ユーザーレベル
    /// </summary>
    [JsonProperty("lv")]
    public int Level { private set; get; }

    /// <summary>
    /// PrimaryKey（ユーザーID）
    /// </summary>
    public override string PrimaryKey => UserId.ToString();
}
