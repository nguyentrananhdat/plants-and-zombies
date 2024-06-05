using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicshooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootOrigin;
    public float cooldown;
    private bool canshoot;
    public float range;
    public LayerMask shootMask;
    private GameObject target;
    public int heathy = 4;
    private AudioSource source;
    public AudioClip[] shootClips;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        Invoke("ResetCooldown", cooldown);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);

        if (hit.collider)
        {
            target = hit.collider.gameObject;
            Shoot();
        }
    }

    void ResetCooldown()
    {
        canshoot = true;
    }

    void Shoot()
    {
        if (!canshoot)
            return;
        source.PlayOneShot(shootClips[Random.Range(0, shootClips.Length)]);
        canshoot = false;
        Invoke("ResetCooldown", cooldown);

        GameObject mtBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
    }
}
