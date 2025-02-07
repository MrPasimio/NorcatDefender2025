using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public LoadImagesFromGoogleDrive assetLoader;



    //TESTING///
    public SpriteRenderer testSpriteRenderer;
    public int shipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
       // assetLoader.GetShips();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Storage.populateShips();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            testSpriteRenderer.sprite = Storage.shipSprites[shipIndex];
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            AdvanceShips();
        }
    }

    
    public void AdvanceShips()
    {
        shipIndex++;
        if(shipIndex >= Storage.shipSprites.Count)
        {
            shipIndex = 0;
        }
    }


}
