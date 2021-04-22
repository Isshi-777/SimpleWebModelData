using Newtonsoft.Json;

/// <summary>
/// マスターデータ「アイテム」のデータ
/// </summary>
public class MasterData_Item : AWebModelData
{
    /// <summary>
    /// アイテムID
    /// </summary>
    [JsonProperty("id")]
    public long Id { private set; get; }

    /// <summary>
    /// アイテム名
    /// </summary>
    [JsonProperty("name")]
    public string Name { private set; get; }

    /// <summary>
    /// PrimaryKey（アイテムID）
    /// </summary>
    public override string PrimaryKey => WebModelDataHelper.GeneratePrimaryKey(this.Id.ToString());
}
