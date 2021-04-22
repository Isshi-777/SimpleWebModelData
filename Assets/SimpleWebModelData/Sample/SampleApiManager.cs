// API通信ではなくローカルのファイルを読み込む
#define LOAD_LOCAL_FILE

using System.Collections;
using UnityEngine;


/// <summary>
/// APIマネージャー（サンプル）
/// </summary>
public class SampleApiManager : MonoBehaviourSingleton<SampleApiManager>
{
    /// <summary>
    /// 現行のAPIの進行状況
    /// </summary>
    public float CurrentProgress { private set; get; }

    /// <summary>
    /// API通信
    /// </summary>
    /// <param name="url">URL</param>
    /// <param name="onCompleted">API終了後のイベント</param>
    public Coroutine ConnectApi(string url, System.Action<string> onCompleted)
    {
        return StartCoroutine(ConnectApi_IE(url, onCompleted));
    }

    /// <summary>
    /// API通信
    /// </summary>
    /// <param name="url">URL</param>
    /// <param name="onCompleted">API終了後のイベント</param>
    private IEnumerator ConnectApi_IE(string url, System.Action<string> onCompleted)
    {
        Debug.Log(" Connect api URL -> " + url);
        this.CurrentProgress = 0.0f;

#if LOAD_LOCAL_FILE

        // Resources.LoadAsyncでのローカルファイル読みこみ

        ResourceRequest load = Resources.LoadAsync<TextAsset>(url);
        yield return load;

        while (!load.isDone)
        {
            this.CurrentProgress = load.progress;
            yield return null;
        }

        this.CurrentProgress = 1.0f;

        if (onCompleted != null)
        {
            var asset = load.asset;
            if (asset != null)
            {
                var textAsset = asset as TextAsset;
                if (textAsset != null)
                {
                    onCompleted(textAsset.text);
                }
            }
        }
#else

        // API通信

        WWW www = new WWW(url);
        while (!www.isDone)
        {
            this.CurrentProgress = www.progress;
            yield return null;
        }

        this.CurrentProgress = 1.0f;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(" Download Error ! -> " + url + " : Error message ->" + www.error);
        }
        else
        {
            if (onCompleted != null)
            {
                onCompleted(www.text);
            }
        }
#endif
    }
}
