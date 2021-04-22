using Newtonsoft.Json;

/// <summary>
/// Json化するデータの基底クラス
/// </summary>
public abstract class AJsonModelData
{
    /// <summary>
    /// 自身のJsonを作成する
    /// </summary>
    /// <returns>Jsonテキスト</returns>
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}
