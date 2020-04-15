using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Animator simplenav;
    public Animator inventoryholder;
    public bool MenuOpen;
    
    
    public PlayerController pc;
    public int PartyHat;
    public GameObject inventoryHat;
    public bool wearHat;
    public GameObject Birthdayhat;
    
    public int goldCount;
    public Text goldText;

    public Button ShopHat;
    public Button ShopSlime;
    public Button ShopSkelly;

    public bool ownHat;
    public bool ownSlime;
    public bool ownSkelly;

    // Start is called before the first frame update
    void Start()
    {
        goldCount = PlayerPrefs.GetInt("Gold");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Gold" , goldCount);

        goldText.text = "Gold:" + goldCount;
        PartyHat = PlayerPrefs.GetInt("PartyHat");

        if (PartyHat == 1)
        {
            inventoryHat.SetActive(true);
        }

        if (wearHat == true)
        {
            pc.moveSpeed = 8;
            pc.jumpSpeed = 18;
            Birthdayhat.SetActive(true);
        }

        if(wearHat == false)
        {
            pc.moveSpeed = 5;
            pc.jumpSpeed = 10;
            Birthdayhat.SetActive(false);
        }

        if (goldCount >= 1 && ownHat == false)
        {
            ShopHat.interactable = true;
        }
    }

    public void OpenNav()
    {
        if (MenuOpen == false)
        {
            simplenav.SetBool("Open", true);
            Time.timeScale = 0;
            MenuOpen = true;
        }

        else if (MenuOpen == true)
        {
            simplenav.SetBool("Open", false);
            Time.timeScale = 1;
            MenuOpen = false;
        }
    }

    public void CloseNav()
    {
            simplenav.SetBool("Open", false);
            Time.timeScale = 1;
            MenuOpen = false;
    }
    
    public void OpenIn()
    {
            inventoryholder.SetBool("Open", true);
    }

    public void BuyHat()
    {
        goldCount -= 1;
        PlayerPrefs.SetInt("PartyHat", 1);
        ShopHat.interactable = false;
        ownHat = true;
    }

    public void PutOnHat()
    {
        wearHat = true;
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("PartyHat", 0);
        inventoryHat.SetActive(false);
        wearHat = false;
    }
}
