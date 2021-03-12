using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{

    public float speed = 20f;
    
    Rigidbody2D rb;
    Animator anim;

    public int dmg = 10;


    // ----------------------- 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (!col.CompareTag("arrow") && !col.CompareTag("life-potion")) StartCoroutine(Boom());
    }

    void Update() {
        
        if (transform.position.y > 6){
            Destroy(gameObject);
        }

    }

    IEnumerator Boom(){
        gameObject.GetComponent<Collider2D>().enabled = false;
        rb.velocity = new Vector2(0, 0);
        anim.SetTrigger("boom");
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }


}
