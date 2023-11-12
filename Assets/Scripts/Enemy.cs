using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D HIT)
    {
        if (HIT.tag == "Player")
        {
            HIT.GetComponent<PlayerBehavior>().LoseLife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (HIT.name == "Projectile")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(HIT.gameObject);
            Destroy(this.gameObject);
        }
    }
}
