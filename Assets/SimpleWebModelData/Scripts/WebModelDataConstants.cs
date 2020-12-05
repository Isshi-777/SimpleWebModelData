using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WebModelData関係の定数クラス
/// </summary>
public static class WebModelDataConstants
{
    /// <summary>
    /// 識別名を指すKeyの列挙
    /// </summary>
    public enum EDataIdentificationKey
    {
        // MasterData（マスターデータはテーブルごとにJsonを用意する場合は１つで大丈夫、1つのJsonに全マスタを含める場合は個別に定義）
        MasterData_Common,

        // UserData

        // InstantData
    }

    /// <summary>
    /// 識別名のDictionary
    /// </summary>
    private static readonly Dictionary<EDataIdentificationKey, string> IdentificationNameDic = new Dictionary<EDataIdentificationKey, string>()
    {
        // MasterData（マスターデータはテーブルごとにJsonを用意する場合は識別名は不要、1つのJsonに全マスタを含める場合は個別に定義）
        { EDataIdentificationKey.MasterData_Common, "" },

        // UserData

        // InstantData
    };

    /// <summary>
    /// 識別名を返す
    /// </summary>
    /// <param name="key">識別名を指すKey</param>
    /// <returns>識別名</returns>
    public static string GetIndifinitionName(EDataIdentificationKey key)
    {
        string result = string.Empty;
        if (!IdentificationNameDic.TryGetValue(key, out result))
        {
            Debug.LogError(" Inidifinition name is not found !!! " + key);
        }

        return result;
    }
}
