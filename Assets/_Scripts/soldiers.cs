using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldiers : MonoBehaviour
{

    bool alive;

    Animator anim;

    public float mvSpeed = 0.4f;

    public int dmg = 10;

    float x;

    float maxHealth = 50f;

    // ----------------------- 

    void Start()
    {
        anim = GetComponent<Animator>();
        alive = true;
    }

    void Update(){

    }
    
    void FixedUpdate()
    {
        if (alive) {
            Move();
            anim.SetBool("walking", true);
        }
    
    }

    void Move() {
        transform.position += new Vector3(0,-1,0) * Time.deltaTime * mvSpeed;
    }

    public void TakeDamage(float dmg_taken)
    {
        maxHealth -= dmg_taken;
        if (maxHealth <= 0) {
            StartCoroutine("Die");

        }
    }

    public IEnumerator Die() {
        alive = false;
        anim.SetTrigger("dead");
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){

        if (col.CompareTag("shot")) {
            FireBallBehavior fireball = GameObject.FindGameObjectWithTag("shot").GetComponent<FireBallBehavior>();
            TakeDamage(fireball.dmg);
        }

    }

}
