using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    public GameObject sunObject;
    public float Cooldown;

    private void Start()
    {
        InvokeRepeating("SpawnSun", Cooldown,Cooldown);
    }

    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject,new Vector3(transform.position.x + Random.Range(-.5f,.5f),transform.position.y + Random.Range(0f,.5f)),Quaternion.identity);
        mySun.GetComponent<Sun>().dropToYPos = transform.position.y - 0.6f;
    }
}
