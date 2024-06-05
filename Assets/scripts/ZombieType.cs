using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New ZombieType",menuName ="Zombie")]
public class ZombieType : ScriptableObject
{
    public int health;
    public float speed;
    public int damage;
    public Sprite sprite;
    public Sprite deathSprite;
    public float range = .5f;
    public float eatCooldown = 1f;
    public AudioClip[] hitClips;
}
