﻿/// <summary>
/// マスターデータテーブルの基底クラス
/// </summary>
/// <typeparam name="T">AWebModelData</typeparam>
public abstract class AMasterDataTable<T> : AWebModelDataListContainer<T> where T : AWebModelData
{
    /// <summary>
    /// テーブル名
    /// </summary>
    public abstract string TableName { get; }

    /// <summary>
    /// 識別Key（各マスターがそれぞれ１つのJsonの際の値）
    /// </summary>
    public override WebModelDataConstants.EDataIdentificationKey IdentificationKey => WebModelDataConstants.EDataIdentificationKey.MasterData_Common;
}
