﻿using Newtonsoft.Json;

/// <summary>
/// 単純なデータ「アイテム情報」のデータ
/// </summary>
public class SimpleData_Item : AWebModelData
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
