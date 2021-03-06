using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehav : SteerableBehaviour
{

    bool alive;

    Animator anim;

    float maxHealth = 70;

    public int dmg = 20;

    float angle = 0;

    // ----------------------- 

    void Start(){

        anim = GetComponent<Animator>();

        alive = true;

    }

    private void FixedUpdate()
    {
        if (alive){
            angle += 0.1f;
            Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
            float x = Mathf.Sin(angle);
            // float y = Mathf.Cos(angle);

            Thrust(x, -1);

        }
        
    }


    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    void TakeDamage(float dmg_recieved)
    {
        maxHealth -= dmg_recieved;
        if (maxHealth <= 0){
            StartCoroutine("Die");
        }
    }

    public IEnumerator Die() {
        alive = false;
        anim.SetTrigger("dead");
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){

        if (col.CompareTag("shot")) {
            FireBallBehavior fireball = GameObject.FindGameObjectWithTag("shot").GetComponent<FireBallBehavior>();
            TakeDamage(fireball.dmg);
        }

    }


}
