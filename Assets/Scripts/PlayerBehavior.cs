using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{


    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public float playerSpeed;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 4f;
    public int lives;
    public TextMeshProUGUI lifeText;
    public int shield;
    public TextMeshProUGUI shieldText;
    private bool _shieldActive; 


    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6f;
        shield = 0;
        lives = 3;
        lifeText = GameObject.Find("GameManager").GetComponent<GameManager>().lifeText;
        lifeText.text = "Lives: " + lives;
        shieldText = GameObject.Find("GameManager").GetComponent<GameManager>().shieldText;
        shieldText.text = "Shield: " + shield;
        _shieldActive = false;
    }

    // Update is called once per frame; if your computer runs at 60 fps
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerSpeed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

    void Shooting()
    {
        //if I press SPACE, create a bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
        
        if (shield >= 1)
        {
            LoseShield();
        } else
            lives--;
            lifeText.text = "Lives: " + lives;
        
        if (lives <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void GainLife()
    {
        lives += 1;
        lifeText.text = "Lives:" + lives;
        if (lives >= 3)
        {
            lives = 3;
            lifeText.text = "Lives:" + lives;
        }
    }

    public void ShieldActive()
    {
        _shieldActive = true;
    }

    public void GainShield()
    {
        shield += 1;
        shieldText.text = "Shield: " + shield;
        if (shield >= 1)
        {

        }
        if (shield >= 3)
        {
            shield = 3;
            shieldText.text = "Shield :" + shield;
        }
    }

    public void LoseShield()
    {
        if (shield <= 0)
        {
            if (_shieldActive == true)
            {
                _shieldActive = false;
                return;
            }
            LoseLife();
            shield = 0;
            shieldText.text = "Shield :" + shield;
        }
        shield--;
        shieldText.text = "Shield: " + shield;
    }

}