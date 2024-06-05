using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public Animator ani;

    private bool hasLost;
    public AudioClip loseMusic;
    public AudioClip scream;
    public AudioSource music;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            if (hasLost || other.GetComponent<zombie>().dead)
                return;
            hasLost = true;
            source.PlayOneShot(loseMusic);
            source.PlayOneShot(scream);
            music.Stop();
            ani.Play("deathAnimation");
            Invoke("RestartScene", 5);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
