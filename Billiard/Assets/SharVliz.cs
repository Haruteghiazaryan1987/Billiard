using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharVliz : MonoBehaviour
{
    bool col;
    Vector3 camMot = new Vector3(10, 15, 0);
    int k = 0;
    // Use this for initialization
    void Start()
    {
        col = true;

    }

    // Update is called once per frame
    void Update()
    {
        k++;
        if (col)
        {

            Vector3 n = camMot - transform.position;
            n.Normalize();
            transform.position = transform.position + n * 0.5f;
            if (transform.position.x >= 9)
            {
                col = false;

            }
        }
        if (k>100)
        {
            Vector3 l = Shar.verjTex1 - camMot;
            l.Normalize();
            transform.position = transform.position + l * 0.5f;
            if (transform.position.y <= 2)
            {
                transform.position = Shar.verjTex1;
                GetComponent<Shar>().enabled = false;
                GetComponent<SharVliz>().enabled = false;
            }
        }
    }

}
	
