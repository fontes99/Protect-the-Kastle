using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterBehav : MonoBehaviour
{

    public GameObject arrow;
    public Transform firepoint;

    bool alive;

    public float fireRate = 2f;
    float nextShotTime = 0f;

    float maxHealth = 70;
    float currentHealth;

    public float mvSpeed = 0.5f;

    public int dmg = 20;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) {
            if (transform.position.y > 3){
                Move();
            }
            else Shoot();
        }
    }

    public void Shoot(){
        anim.SetTrigger("shoot");
        if(Time.time >= nextShotTime) {
            
            Instantiate(arrow, firepoint.position, firepoint.rotation);

            nextShotTime = Time.time + 1f/fireRate;
        
        }
    }

    public void TakeDamage(float dmg_taken){
        maxHealth -= dmg_taken;
        if (maxHealth <= 0){
            StartCoroutine("Die");
        }

    }

    void Move(){
        transform.position += new Vector3(0,-1,0) * Time.deltaTime * mvSpeed;
    }

    public IEnumerator Die(){
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
