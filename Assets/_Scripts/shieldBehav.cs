using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBehav : MonoBehaviour
{
    public GameObject player;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // gameObject.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && player.GetComponent<PlayerController>().currentMana > 30){
            anim.SetBool("on", true);

            // gameObject.GetComponent<Collider2D>().enabled = true;
            // player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<PlayerController>().ShieldIsUp = true;

        }
        else{
            // gameObject.GetComponent<Collider2D>().enabled = false;
            // player.GetComponent<Collider2D>().enabled = true;
            player.GetComponent<PlayerController>().ShieldIsUp = false;

            anim.SetBool("on", false);
        }
    }
}
