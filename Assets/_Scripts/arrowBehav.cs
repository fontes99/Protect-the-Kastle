using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBehav : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rb;

    public int dmg = 10;

    // ----------------------- 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
        rb.velocity = -transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Kastle") || col.CompareTag("Player")) Destroy(gameObject);
    }

    void Update() {
    
        if (transform.position.y < -6){
            Destroy(gameObject);
        }
    }
}
