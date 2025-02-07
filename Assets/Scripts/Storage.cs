using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
   public static string shipFolderID = "1-zJoINpSafwN40ZPTs8pBeL2MscQd3Zb";
   public static string enemyFolderID = "1Ghz_vFdYl9BbeX9LG18Xo_9HlyHohruA";

   public static List<Sprite> shipSprites = new List<Sprite>();
   public static List<Sprite> enemySprites = new List<Sprite>();

    public static void populateShips()
    {
        shipSprites.Clear();
        GameObject.Find("AssetLoader").GetComponent<LoadImagesFromGoogleDrive>().LoadAssetsFromFolder(shipFolderID, shipSprites);
    }
}
