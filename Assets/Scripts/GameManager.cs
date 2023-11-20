using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject powerUpPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public GameObject shieldPrefab;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("SpawnEnemyTwo", 2f, 4f);
        InvokeRepeating("SpawnEnemyThree", 3f, 5f);
        InvokeRepeating("SpawnPowerUp", 3f, 4f);
        InvokeRepeating("SpawnCoin", 2f, 4f);
        InvokeRepeating("SpawnShield", 2f, 5f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9, 9), 8.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-9, 9), 6.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, new Vector3(Random.Range(-9, 9), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-9, 9), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnShield()
    {
        Instantiate(shieldPrefab, new Vector3(Random.Range(-9, 9), 6.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 45; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }   
    }

    public void GameOver()
    {
        CancelInvoke();
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }

}