using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
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
            HIT.GetComponent<PlayerBehavior>().GainShield();
            HIT.GetComponent<PlayerBehavior>().ShieldActive();
            Destroy(this.gameObject);
        }
    }
}
