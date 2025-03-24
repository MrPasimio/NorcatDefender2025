using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float yPos;
    public float zPos;
    public float xRange;
    public float spawnDelay;
    public float spawnSpeed = 2;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

  IEnumerator SpawnEnemy()
    {
        GameObject currentEnemy = Instantiate(
            enemyPrefab,
            new Vector3(
                        Random.Range(-xRange, xRange),
                        yPos,
                        zPos),
            enemyPrefab.transform.rotation)
            ;
        currentEnemy.GetComponent<MoveDown>().speed = spawnSpeed;
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnEnemy());
    }
}
