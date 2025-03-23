using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy Loader Initiated");
        GetEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        //Test
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"{Storage.enemySprites.Count} enemy sprites loaded.");
        }
    }

    public void GetEnemies()
    {
        Storage.populateEnemies();
    }
}
