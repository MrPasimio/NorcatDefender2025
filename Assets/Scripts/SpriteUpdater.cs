using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdater : MonoBehaviour
{
    public enum spriteType { SHIP, ENEMY };
    public spriteType objectType;

    // Start is called before the first frame update
    void Start()
    {
        if(objectType == spriteType.SHIP && Storage.currentShip != null)
        {
            GetComponent<SpriteRenderer>().sprite = Storage.currentShip;
        }
    }

 
}
