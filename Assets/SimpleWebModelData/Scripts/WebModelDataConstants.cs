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
    public enum EDataIndifinitionKey
    {
        // MasterData

        // UserData

        // InstantData
    }

    /// <summary>
    /// 識別名のDictionary
    /// </summary>
    private static readonly Dictionary<EDataIndifinitionKey, string> IndifinitionNameDic = new Dictionary<EDataIndifinitionKey, string>()
    {
        // MasterData

        // UserData

        // InstantData
    };

    /// <summary>
    /// 識別名を返す
    /// </summary>
    /// <param name="key">識別名を指すKey</param>
    /// <returns>識別名</returns>
    public static string GetIndifinitionName(EDataIndifinitionKey key)
    {
        string result = string.Empty;
        if (!IndifinitionNameDic.TryGetValue(key, out result))
        {
            Debug.LogError(" Inidifinition name is not found !!! " + key);
        }

        return result;
    }
}
