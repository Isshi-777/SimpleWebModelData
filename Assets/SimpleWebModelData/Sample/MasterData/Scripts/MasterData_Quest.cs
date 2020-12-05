using Newtonsoft.Json;

/// <summary>
/// マスターデータ「クエスト」の情報
/// </summary>
public class MasterData_Quest : AWebModelData
{
    /// <summary>
    /// クエストID
    /// </summary>
    [JsonProperty("id")]
    public long Id { private set; get; }

    /// <summary>
    /// クエスト名
    /// </summary>
    [JsonProperty("name")]
    public string Name { private set; get; }

    /// <summary>
    /// 推奨レベル
    /// </summary>
    [JsonProperty("recommend_lv")]
    public int RecommendLevel { private set; get; }

    /// <summary>
    /// PrimaryKey（クエストID）
    /// </summary>
    public override string PrimaryKey => WebModelDataHelper.GeneratePrimaryKey(this.Id.ToString());
}
