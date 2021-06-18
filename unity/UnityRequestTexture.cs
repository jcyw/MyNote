using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class UnityRequestTexture : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("http://www.my-server.com/myimage.png"))
        {
            yield return uwr.SendWebRequest();
            //isDone	当 UnityWebRequest 结束与远程服务器的通信后，返回 true。（只读）
            //uwr.isDone
            //downloadProgress	返回一个 0.0 和 1.0 之间的浮点值，用于表示从服务器下载主体数据的进度。（只读）

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);
            }
        }
    }
}