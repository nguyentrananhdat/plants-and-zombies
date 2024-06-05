using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMower : MonoBehaviour
{
    public bool isMoving;

    public float speed = 1;

    public AudioClip sound;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            if (!isMoving)
                source.PlayOneShot(sound);

            other.GetComponent<zombie>().Hit(100,false);

            isMoving = true;
            Destroy(gameObject, 8);
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
