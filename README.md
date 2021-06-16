# SimpleWebModelDataProject

## 概要
Json.Netを使用しての簡単なWebModelDataのサンプル（MessagePack for C#はまた別で）  
※「WebModelData」 => 主にAPIのレスポンスで降ってくる情報やマスターデータなどのこと

## 目的
サーバーから降ってきたデータなど指定のデータはreadonlyであることを保証したい 
  
例  
```C#
// テストデータ
public class TestData
{
　　// う～ん・・・
    // 外部から変更できないようにしたい
    // 変数名は「UserId」にしたい！(JsonのKeyが「user_id」でサーバーもその認識だから変えられない・・などの理由)
    public int user_id;
    
    // う～ん・・・
    // 外部から変更できないようにしたが変数とプロパティがあって少しやだ
    [SerializeField] private int user_id;
    public int UserId { get { return this.user_id; } }
    
    // こんな感じにしたい！
    // 値を変更したい場合は関数を作成して変更
    [JsonKey("user_id")]
    public int UserId { get; private set; }
}
```  

## 入っているサンプル
・単純なデータ  
・マスターデータ

## 備考
本プロジェクトには「Json.Net Version 13.0.1」が使用されています  
Json.NET  
https://www.newtonsoft.com/json
