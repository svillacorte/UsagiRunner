using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    public MenuManager mm;
    public AudioSource goldSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            mm.goldCount += 1;
            goldSound.Play();
            this.gameObject.SetActive(false);
        }
    }

}
