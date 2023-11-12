using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float tempValue = Random.Range(0f, 1f);
        transform.localScale = new Vector3(1, 1, 1) * tempValue;
        tempValue = Random.Range(0.1f, 0.6f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, tempValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
