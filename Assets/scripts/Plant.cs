using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int health;

    public Tile tile;

    private void Start()
    {
        gameObject.layer = 9;
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            tile.hasplant = false;
            Destroy(gameObject);
        }
    }
}
