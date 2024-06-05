using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class plantslot : MonoBehaviour
{
    public Sprite plantsprite;

    public GameObject plantObject;

    public int price;

    public Image icon;

    public TextMeshProUGUI pricetext;

    private gamemanage gms;

    private void Start()
    {
        gms = GameObject.Find("GameManage").GetComponent<gamemanage>();
        GetComponent<Button>().onClick.AddListener(buyplant);
    }

    private void buyplant()
    {
        if (gms.suns >= price && !gms.currentplant)
        {
            gms.suns -= price;
            gms.buyplant(plantObject, plantsprite);
        }
    }

    private void OnValidate()
    {
        if (plantsprite)
        {
            icon.enabled = true;
            icon.sprite = plantsprite;
            pricetext.text = price.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }

}
