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

    public Button ShopBoost;
    public Button ShopSlime;
    public Button ShopSkelly;

    public bool ownBoost;
    public bool ownSlime;
    public bool ownSkelly;
    public int BoostUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        BoostUpgrade = PlayerPrefs.GetInt("Boost");
        if(BoostUpgrade == 1)
        {
            pc.BoostUpgrade();
        }
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


        if (goldCount >= 10 && ownBoost == false)
        {
            ShopBoost.interactable = true;
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

    public void CloseIn()
    {
        inventoryholder.SetBool("Open", false);
    }

    public void BuyBoost()
    {
        goldCount -= 10;
        PlayerPrefs.SetInt("Boost", 1);
        ShopBoost.interactable = false;
        ownBoost = true;
    }

    public void PutOnHat()
    {
        wearHat = true;
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("Boost", 0);
        goldCount = PlayerPrefs.GetInt("Gold");
        goldText.text = "Gold:" + goldCount;
        pc.maxboosttime = 5;
        pc.boosttime = 5;
        pc.boostbar.transform.localScale = new Vector3(1, 1, 1);
        ownBoost = false;
    }
}
