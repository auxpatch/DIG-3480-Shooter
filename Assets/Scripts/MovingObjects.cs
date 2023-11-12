using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public int objectType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objectType == 1)
        {
            //You are a bullet
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
        } else if (objectType == 2)
        {
            //You are enemyOne
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 3f);
        } else if (objectType == 3)
        {
            //You are enemyTwo
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 5f);
        } else if (objectType == 4)
        {
            //You are enemyThree
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 7f);
        }

        if (transform.position.y > 11f || transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }
}
