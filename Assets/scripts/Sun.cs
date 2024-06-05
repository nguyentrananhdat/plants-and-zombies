using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float dropToYPos;

    private float speed = .15f;

    private void Start()
    {
        
        Destroy(gameObject,Random.Range(15,20));
    }

    private void Update()
    {
        if(transform.position.y > dropToYPos)
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
