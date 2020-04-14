using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Fence;
    public Animator FrontBamboo;
    public Animator BackBamboo;
    public Animator Clouds;
    public PlayerController pc;
    public Animator player;

    void Start()
    {
        StartCoroutine("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Tutorial()
    {
        pc.moveSpeed = 0;
        yield return new WaitForSeconds(7f);
        Fence.enabled = true;
        FrontBamboo.enabled = true;
        BackBamboo.enabled = true;
        Clouds.enabled = true;
        player.SetBool("run", true);
        pc.moveSpeed = 5;
    }
}
