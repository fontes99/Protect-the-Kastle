using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{

    GameManager gm;

    public float speed = 20f;
    Rigidbody2D rb;

    public int dmg = 10;

    // ----------------------- 

    void Start()
    {
        gm = GameManager.GetInstance();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (!col.CompareTag("arrow")) Destroy(gameObject);
    }

    void Update() {
        
        if (gm.gameState == GameManager.GameState.GAME) {
            if (transform.position.y > 6){
                Destroy(gameObject);
            }

            rb.velocity = transform.up * speed;
        }
        else rb.velocity = new Vector2(0f, 0f);
    }


}
