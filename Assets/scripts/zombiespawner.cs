using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombiespawner : MonoBehaviour
{
    public Transform[] spawnpoints;

    public GameObject zombie;

    public ZombieTypeProb[] ZombieTypes;

    private List<ZombieType> probList = new List<ZombieType>();

    public int zombieMax;
    public int zombiesSpawned;
    public Slider progressBar;
    public float zombieDelay = 5;

    private void Start()
    {
        InvokeRepeating("SpawnZombie", 15, zombieDelay);

        foreach(ZombieTypeProb zom in ZombieTypes)
        {
            for(int i=0;i< zom.probability; i++)
            {
                probList.Add(zom.type);
            }
        }
        progressBar.maxValue = zombieMax;
    }

    private void Update()
    {
        progressBar.value = zombiesSpawned;
    }

    void SpawnZombie()
    {
        if (zombiesSpawned >= zombieMax)
            return;
        zombiesSpawned++;
        int r = Random.Range(0, spawnpoints.Length);
        GameObject myZombie = Instantiate(zombie,spawnpoints[r].position,Quaternion.identity);
        myZombie.GetComponent<zombie>().type = probList[Random.Range(0, probList.Count)];
        if (zombiesSpawned >= zombieMax)
            myZombie.GetComponent<zombie>().LastZombie = true;
    }
}

[System.Serializable]
public class ZombieTypeProb
{
    public ZombieType type;
    public int probability;
}