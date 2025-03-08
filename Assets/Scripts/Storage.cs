using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
    public static bool isLoading;

   public static string shipFolderID = "1-zJoINpSafwN40ZPTs8pBeL2MscQd3Zb";
   public static List<Sprite> shipSprites = new List<Sprite>();
   public static Sprite currentShip;

   public static string enemyFolderID = "1Ghz_vFdYl9BbeX9LG18Xo_9HlyHohruA";
   public static List<Sprite> enemySprites = new List<Sprite>();
    

    public static void populateShips()
    {
        Debug.Log("Populating Ships");
        isLoading = true;
        shipSprites.Clear();
        GameObject.Find("AssetLoader").GetComponent<LoadImagesFromGoogleDrive>().LoadAssetsFromFolder(shipFolderID, shipSprites);
        Debug.Log($"{shipSprites.Count} ships loaded");
    }
}
