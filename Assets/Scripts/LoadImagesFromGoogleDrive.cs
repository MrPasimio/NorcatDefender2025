using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LoadImagesFromGoogleDrive : MonoBehaviour
{
    [Header("Links and IDs")]
    [SerializeField] private  string googleScriptUrl = "https://script.google.com/macros/s/AKfycbxvIZaHZyxL8GqVxYkE6ToYqhm-2KppUwUtwoSESnuErHx5W4HzIFqwS039LHsWv7MVEQ/exec";
    [SerializeField] private string shipFolderID = "1-zJoINpSafwN40ZPTs8pBeL2MscQd3Zb";
    [SerializeField] private string enemyFolderID= "1Ghz_vFdYl9BbeX9LG18Xo_9HlyHohruA";



    public Transform imageContainer; // Parent object for sprites
    public GameObject spritePrefab; // Prefab with a SpriteRenderer component

    
    public void GetShips()
    {
        Debug.Log($"Running GetShips with {shipFolderID}");
        LoadAssetsFromFolder(shipFolderID);
    }

    public void GetEnemies()
    {
        LoadAssetsFromFolder(enemyFolderID);
    }

    private void LoadAssetsFromFolder(string folderId)
    {
        StartCoroutine(GetImageList(folderId));
    }

    IEnumerator GetImageList(string folderId)
    {
        Debug.Log($"Running GetImageList with {folderId}");

        string requestUrl = googleScriptUrl + "?folderId=" + folderId;
        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            List<GoogleDriveFile> files = JsonUtility.FromJson<FileListWrapper>("{\"files\":" + request.downloadHandler.text + "}").files;
            foreach (GoogleDriveFile file in files)
            {
                StartCoroutine(DownloadAndCreateSprite(file.url));
            }
        }
        else
        {
            Debug.LogError("Failed to get file list: " + request.error);
        }
    }

    IEnumerator DownloadAndCreateSprite(string url)
    {
        Debug.Log($"Running DownloadAndCreateSprite with {url}");

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            GameObject newSpriteObj = Instantiate(spritePrefab, imageContainer);
            newSpriteObj.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            Debug.LogError("Image download failed: " + request.error);
        }
    }

    [System.Serializable]
    public class GoogleDriveFile
    {
        public string name;
        public string url;
    }

    [System.Serializable]
    public class FileListWrapper
    {
        public List<GoogleDriveFile> files;
    }
}

