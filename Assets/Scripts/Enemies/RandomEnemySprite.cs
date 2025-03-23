using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Storage.enemySprites.Count > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Storage.enemySprites[Random.Range(0, Storage.enemySprites.Count)];
        }
    }

    
}
