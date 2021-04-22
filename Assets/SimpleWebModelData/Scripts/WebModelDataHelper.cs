using System.Text;
using UnityEngine;

/// <summary>
/// WebModelData関係のヘルパークラス
/// </summary>
public static class WebModelDataHelper
{
    /// <summary>
    /// PrimaryKeyを作成する
    /// </summary>
    /// <param name="keys">要素となるKeyのリスト</param>
    /// <returns>PrimaryKey</returns>
    public static string GeneratePrimaryKey(params string[] keys)
    {
        if (keys == null || keys.Length == 0)
        {
            Debug.LogError(" KeyList is null or empty !!! ");
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();
        foreach (var key in keys)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError(" Key is null or empty !!! ");
                return string.Empty; // 強制終了させる
            }
            else
            {
                sb.Append(key).Append("-");
            }
        }

        sb.Remove(sb.Length - 1, 1); // 末尾の「-」を削除
        return sb.ToString();
    }
}
