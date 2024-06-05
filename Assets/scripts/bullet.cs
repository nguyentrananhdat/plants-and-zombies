using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;

    public float speed = 2f;

    public bool freeze;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<zombie>(out zombie Zombie))
        {
            Zombie.Hit(damage,freeze);
            Destroy(gameObject);
        }
    }
}
