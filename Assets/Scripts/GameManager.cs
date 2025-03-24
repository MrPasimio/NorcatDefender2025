using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreDisplay;
    public GameObject gameOverText;
    public float difficultyMultiplier;
    public float secondsBetweenLevels;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DifficultyUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScore();
    }

    IEnumerator DifficultyUp()
    {
        yield return new WaitForSeconds(secondsBetweenLevels);
       Spawner enemySpawn = GameObject.Find("EnemySpawner").GetComponent<Spawner>();
        enemySpawn.spawnDelay *= (1 - difficultyMultiplier);
        enemySpawn.spawnSpeed *= (1 + difficultyMultiplier);
        GameObject.Find("Player").GetComponent<PlayerMovement>().shootDelay *= (1 - difficultyMultiplier);
        StartCoroutine(DifficultyUp());
    }

    public IEnumerator GameOver()
    {
        gameOverText.SetActive(true);
        Destroy(GameObject.Find("Player"));
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }
}
