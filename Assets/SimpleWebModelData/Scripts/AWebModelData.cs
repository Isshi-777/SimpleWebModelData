using Newtonsoft.Json;

/// <summary>
/// WebModelデータの基底クラス
/// </summary>
public abstract class AWebModelData : AJsonModelData
{
    /// <summary>
    /// PrimaryKey
    /// </summary>
    [JsonIgnore]
    public abstract string PrimaryKey { get; }
}
