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
    public GameObject cloudPrefab;
    public int lives;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("SpawnEnemyTwo", 2f, 4f);
        InvokeRepeating("SpawnEnemyThree", 3f, 5f);
        lives = 3;
        livesText.text = "Lives:" + lives;

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

}