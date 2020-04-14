﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUp : MonoBehaviour
{
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc.boosttime += 1;
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }
}
