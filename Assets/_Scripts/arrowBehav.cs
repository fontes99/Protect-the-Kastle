using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBehav : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rb;

    public int dmg = 10;

    GameManager gm;

    // ----------------------- 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameManager.GetInstance();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (!col.CompareTag("shot")) Destroy(gameObject);
    }

    void Update() {
        if (gm.gameState == GameManager.GameState.GAME) {
    
            rb.velocity = -transform.up * speed;

            if (transform.position.y < -6){
                Destroy(gameObject);
            }
        }
        else rb.velocity = new Vector2(0f, 0f);
    }
}
