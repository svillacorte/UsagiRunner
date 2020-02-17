using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this line is needed to reference UI items like buttons or images
using UnityEngine.SceneManagement; // this calls the scene manager which loads levels(scenes)
using UnityEngine.Audio; 

public class notes2 : MonoBehaviour
{
    public Image myImage;
    public Button myButton;
    public float timer;

    // Start is called before the first frame update
    // Sharmaine Villacorte

    //TIMERS
    // we can create timers using the command Time.deltaTime this means the time since the last
    //frame ended
    // generally we take a float and we add or subtract Time.deltaTime to make a timer

    //AI
    //MOVE TOWARDS
    //Vector3.Moveowards is a command that will move one gameObject towards another one
    // MoveTowards needs 3 things
    // Our current location (Vector 3)
    // A target location (Vector 3)
    // How long it will take to move from point A to point B (usually we set this as a number)
    public Vector3 start;
    public Vector3 finish;
    public float speed;
    public GameObject target; // this is another gameobject that we want to follow

    //INSTANTIATE is a way to make things appear. this could be enemies or loot that enemies drop
    public GameObject money; // this is usually a prefab in the assets folder that we will bring
                             // into our scene

    // ARRAY this is a collection of gameObjects
    public GameObject[] alltheenemies; // the straight brackets signify a collection of gameObjects

    //PLAYER PREFS these are values that are stored between game plays meaning you can leave the
    // app without losing your progress
    public int GB; // this is just a normal int

    void Start()
    {
        //Player Prefs first we need to create a custom player pref

        PlayerPrefs.SetInt("GreenBird", 2); // this changes the Green Player Pref number to 2
        // this value is remembered between gameplay

        // Next we need to check the player refs
        if(PlayerPrefs.HasKey("GreenBird")) // Has key checks to see if the player pref exists
        {
            GB = PlayerPrefs.GetInt("GreenBird"); // this is  taking our normal int and setting
            // the same as our player prefs int
        }

        //Finally we need to use the player prefs to make a change

        if(GB == 2)
        {
            myButton.interactable = true; // this makes the green bird button work
        }

        //ARRAY Step 1 Get the list
        alltheenemies = gameObject.FindGameObjectsWithTag("enemy"); // this gets all the gameObjects
        //tagged enemy when the game starts. you can put this line in Update to make the list
        // update in real time

        //ARRAY Step 2 Change objects inside the list
        //FOR LOOP this lets us run through the list and make changes to all the objects on the list
        for (int i = 0; i < alltheenemies.Length; i++) // this line foes through the array untill it gets
        {
            alltheenemies[i].SetActive(false); // this would turn all the enemies off at once
        }

        // int i = 0 means we start at the top of the list Unity lists start at 0
        // i < alltheenemies.Length this means as long as our current number isn't larger than the whole list
        // so if our list is just 10 we are start at 0 which is lest than 10
        // i++ means we just add one so now we are at 1 which is also less than 10 so we add another
        // now we are at 2 we check again and 2 < 10 so we add another and so on

        StartCoroutine(StartPower()); // this calls the IEnumerator which doesn't run by itself
        // DO NO CALL IEnumerator inside Update
        start = transform.position; // this sets out position to the start position
        finish = target.transform.position; // this gets the targets position


        GameObject loot = Instantiate(money, transform.position, transform.rotation);
        // this above line will bring loot into existence at this location and this rotation
        Destroy(money, 5f); // this line gets rid of our instantiated prefab "money"
        // Instantiate and destroy will cause garbage to accumulate so NOT mobile friendly
        //AUTO POOLING
        GameObject loot = MF_AutoPool.Spawn(money, transform.position, transform.rotation);
        MF_AutoPool.Despawn(this.gameObject, 5f); // this line would be on a script on the money
        //gameobject and would despawn it after 5 seconds
    }

    // Update is called once per frame

   public void BuyFancyOutfit() // public voids are needed if you want a button to call them
    {
        PlayerPrefs.SetInt("FancyOutfit", 2);
    }
    void Update()
    {
        //TIMER
        timer -= Time.deltaTime; // this will subtract from the timer every frame
        timer += Time.deltaTime; // this will add to the timer every frame;
                                 //usually you run one or the other
        finish = target.transform.position; // this gets the targets position in real time
        //MOVE TOWARDS
        Vector3.MoveTowards(start, finish, speed); //usually start is the enemey location
        // and finish is the player location
        // speed is constant
    }

    //Co Routine or IENUMERATOR
    // normally functions read from top to bottom all at once but sometimes we want a break in
    // the function which is why we use a IENUMERATOR
    // Think of this like the start power in SMB

    public IEnumerator StarPower()
    {
        // give Mario start power
        // change music
        // change the sprite
        yield return new WaitForSeconds(5f); // this line lets us wait for 5 seconds
        // star power wears off
        // 
    }

}
