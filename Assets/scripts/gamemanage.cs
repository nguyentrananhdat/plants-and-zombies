using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gamemanage : MonoBehaviour
{
    public GameObject currentplant;
    public Sprite currentplantsprite;
    public Transform tiles;
    public LayerMask tileMask;
    public int suns;
    public TextMeshProUGUI sunText;
    public LayerMask sunMask;

    public AudioClip plantSFX;
    private AudioSource source;

    public AudioSource sunSource;
    public AudioClip sunClip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Win()
    {
        
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        PlayerPrefs.SetInt("levelSave", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void buyplant(GameObject plant, Sprite sprite)
    {
        currentplant = plant;
        currentplantsprite = sprite;
    }

    private void Update()
    {
        sunText.text = suns.ToString();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach (Transform tile in tiles)
            tile.GetComponent<SpriteRenderer>().enabled = false;

        if(hit.collider && currentplant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentplantsprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasplant)
            {
                Plant(hit.collider.gameObject);
            }
        }

        RaycastHit2D sunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);

        if (sunHit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sunSource.pitch = Random.Range(.90f, 1.1f);
                sunSource.PlayOneShot(sunClip);
                suns += 25;
                Destroy(sunHit.collider.gameObject);
            }
        }
    }

    void Plant(GameObject hit)
    {
        source.PlayOneShot(plantSFX);
        GameObject plant = Instantiate(currentplant, hit.transform.position, Quaternion.identity);
        hit.GetComponent<Tile>().hasplant = true;
        plant.GetComponent<Plant>().tile = hit.GetComponent<Tile>();
        currentplant = null;
        currentplantsprite = null;
    }
}
