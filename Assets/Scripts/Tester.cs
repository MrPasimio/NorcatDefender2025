using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public LoadImagesFromGoogleDrive assetLoader;

    // Start is called before the first frame update
    void Start()
    {
        assetLoader.GetShips();
    }

    
}
