/// <summary>
/// クエストのマスターデータテーブル
/// </summary>
public class MasterDataTable_Quest : AMasterDataTable<MasterData_Quest>
{
    /// <summary>
    /// テーブル名
    /// </summary>
    public override string TableName => "Mst_Quest";

    /// <summary>
    /// 簡単なリストを返す（配列）
    /// </summary>
    /// <returns></returns>
    public MasterData_Quest[] GetEasyQuestList()
    {
        return this.dataList.FindAll(x => x.RecommendLevel < 20).ToArray();
    }
}
