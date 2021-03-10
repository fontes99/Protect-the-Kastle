using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehav : MonoBehaviour
{

    bool alive;

    Animator anim;
    public int dmg = 40;

    float maxHealth = 60f;
    float mvSpeed = 1.5f;

    // ----------------------- 

    void Start()
    {
        anim = GetComponent<Animator>();    
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (alive){
            Move();
        }

    }

    void Move(){
        transform.position += new Vector3(0,-1,0) * Time.deltaTime * mvSpeed;
    }

    void TakeDamage(float dmg_taken){
        maxHealth -= dmg_taken;
        if (maxHealth <= 0){
            StartCoroutine("ExplodeMeteorThenDestroy");
        }
    }

    public IEnumerator ExplodeMeteorThenDestroy() {
        soundBehav.PlaySound("boom");
        alive = false;
        anim.SetTrigger("explode");
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
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
