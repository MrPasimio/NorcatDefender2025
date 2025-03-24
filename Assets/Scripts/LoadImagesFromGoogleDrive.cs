


using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LoadImagesFromGoogleDrive : MonoBehaviour
{
    [SerializeField] private string googleScriptUrl = "https://script.google.com/macros/s/AKfycbzBVpXU2AdXpD98xO2DPTjxUa3-Owl_n6d30QbJUX_EBrOieBvHhGxLXYYi8NFDqZuNMw/exec";
    


    // Public method to load sprites from a specified folder into a provided list
    public void LoadAssetsFromFolder(string folderId, List<Sprite> destinationList)
    {
        Debug.Log($"Loading Assets from {folderId}");

        StartCoroutine(GetImageList(folderId, destinationList));
    }

    private IEnumerator GetImageList(string folderId, List<Sprite> destinationList)
    {
        string requestUrl = $"{googleScriptUrl}?folderId={folderId}";
        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            List<GoogleDriveFile> files = JsonUtility.FromJson<FileListWrapper>("{\"files\":" + request.downloadHandler.text + "}").files;
            foreach (GoogleDriveFile file in files)
            {
                Debug.Log($"Google Drive file found: {file.name}");
                yield return StartCoroutine(DownloadAndStoreSprite(file.url, destinationList));
            }
            Storage.isLoading = false;
        }
        else
        {
            Debug.LogError("Failed to get file list: " + request.error);
        }
    }

    private IEnumerator DownloadAndStoreSprite(string url, List<Sprite> destinationList)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        Debug.Log("Content-Type: " + request.GetResponseHeader("Content-Type")); 

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            destinationList.Add(sprite);
        }
        else
        {
            Debug.LogError("Image download failed: " + request.error);
        }
    }

    [System.Serializable]
    private class GoogleDriveFile
    {
        public string name;
        public string url;
    }

    [System.Serializable]
    private class FileListWrapper
    {
        public List<GoogleDriveFile> files;
    }
}


