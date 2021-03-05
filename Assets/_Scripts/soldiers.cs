using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldiers : MonoBehaviour
{

    GameManager gm;

    bool alive;

    Animator anim;

    public float mvSpeed = 0.4f;

    public int dmg = 10;

    float x;

    float maxHealth = 50f;

    // ----------------------- 

    void Start()
    {
        gm = GameManager.GetInstance();
        anim = GetComponent<Animator>();
        alive = true;
    }

    void Update(){

    }
    
    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
     
        // StartCoroutine(MoveLogic());
        if (alive) {
            Move();
            anim.SetBool("walking", true);
        }
    
    }

    void Move() {
        transform.position += new Vector3(0,-1,0) * Time.deltaTime * mvSpeed;
    }

    // IEnumerator MoveLogic(){

    //     // andar um pouco numa direção x random e -y
    //     // ficar idle por 3s
    //     // repeat

    // }

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
