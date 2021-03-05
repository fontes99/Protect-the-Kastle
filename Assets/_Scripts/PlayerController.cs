using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement logic done by https://www.youtube.com/watch?v=Ehk9fKBwS3Y&t=13s&ab_channel=MuddyWolfGames

public class PlayerController : MonoBehaviour
{

    Vector3 mousePos;
    public float movSpeed = 0.2f;
    Rigidbody2D rb;
    SpriteRenderer spr;
    Vector2 position = new Vector2(0f,0f);

    float difMovX;

    Animator anim;

    public Transform firePoint;
    public GameObject fireball;

    public float fireRate = 7f;
    float nextShotTime = 0f;

    int maxHealth = 100;
    int currentHealth;

    public HealthBarBehav healthBar;

    public int manaCost = 5;
    int maxMana = 100;
    int currentMana;

    public float manaRegenRate = 10f;
    float nextManaRegen = 0f;

    public HealthBarBehav manaBar;

    bool alive;

    // ----------------------- 

    private void Start(){

        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        alive = true;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxHealth(currentMana);
    
    }

    private void Update(){
        
        if (Input.GetButton("Fire1") && alive){
            Shoot();
        }

    }

    void FixedUpdate()
    {
       
        if (alive) {
            Move();
        }

        if (currentMana < maxMana && Time.time >= nextManaRegen){
            currentMana += 1;
            manaBar.SetHealth(currentMana);
            nextManaRegen = Time.time + 1f/manaRegenRate;

        }

    }    

    public void Shoot()
    {

        if(Time.time >= nextShotTime && currentMana > 0) {
            
            Instantiate(fireball, firePoint.position, firePoint.rotation);

            currentMana -= manaCost;
            manaBar.SetHealth(currentMana);

            soundBehav.PlaySound("fireball");
            nextShotTime = Time.time + 1f/fireRate;
        
        }

    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);

        anim.SetTrigger("dmg");
        
        if (currentHealth <= 0){
            Die();
        }
        
        else soundBehav.PlaySound("dmg");
    }

    public void Die()
    {
        alive = false;
        StartCoroutine("PlsDie");
        soundBehav.PlaySound("die");
    }

    IEnumerator PlsDie(){
        anim.SetTrigger("die");
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        // Destroy(gameObject);
    }

    void Move(){

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector2.Lerp(transform.position, mousePos, movSpeed);

        difMovX = mousePos.x - transform.position.x;

        if (difMovX < -0.2f) {
            anim.SetBool("walking", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        }

        if (difMovX > 0.2f) {
            anim.SetBool("walking", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if (difMovX > -0.2f && difMovX < 0.2f) {
            anim.SetBool("walking", false);
        }

        rb.MovePosition(position);
    
    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("Meteor")) {
            MeteorBehav met = GameObject.FindGameObjectWithTag("Meteor").GetComponent<MeteorBehav>();
            StartCoroutine(met.ExplodeMeteorThenDestroy());
            TakeDamage(met.dmg);
        }

        if (col.CompareTag("Enemy")) {
            soldiers soldiers = GameObject.FindGameObjectWithTag("Enemy").GetComponent<soldiers>();
            StartCoroutine(soldiers.Die());
            TakeDamage(soldiers.dmg);
        }
        if (col.CompareTag("Dragon")) {
            DragonBehav drag = GameObject.FindGameObjectWithTag("Dragon").GetComponent<DragonBehav>();
            StartCoroutine(drag.Die());
            TakeDamage(drag.dmg);
        }

        if (col.CompareTag("arrow")) {
            arrowBehav arrow = GameObject.FindGameObjectWithTag("arrow").GetComponent<arrowBehav>();
            TakeDamage(arrow.dmg);
            
        }

        if (col.CompareTag("Balista")) {
            shooterBehav balista = GameObject.FindGameObjectWithTag("Balista").GetComponent<shooterBehav>();
            StartCoroutine(balista.Die());
            TakeDamage(balista.dmg);
            
        }


    }
   
}
