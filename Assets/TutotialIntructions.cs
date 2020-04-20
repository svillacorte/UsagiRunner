using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;

public class TutotialIntructions : MonoBehaviour
{
    public Text textJump;
    public Text textBoost;
    public Text textON;
    public Text textOFF;
    public 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (textON.enabled == true)
        {
            if (CnInputManager.GetButtonDown("Jump"))
            {
                textJump.enabled = false;
            }
        }

        if (textON.enabled == true)
        {
            if (CnInputManager.GetButtonDown("Boost"))
            {
                textBoost.enabled = false;

            }
        }

        //if swipeleft == true
        //textattack.enabled = false

        //if swipedown == true
        //textduck.enabled = false
    }

            private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.tag == "Player")
                {
                    if (textON != null)
                    {
                        textON.enabled = true;
                    }

                    if (textOFF != null)
                    {
                        textOFF.enabled = false;
                    }

                }
            }
        }
