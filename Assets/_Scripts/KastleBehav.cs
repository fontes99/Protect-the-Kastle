﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KastleBehav : MonoBehaviour
{

    public HealthBarBehav healthBar;

    int maxHealth = 1000;
    int currentHealth;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

        gm = GameManager.GetInstance();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg_taken) {

        currentHealth -= dmg_taken;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <=0 ) LoseGame();

    }

    public void LoseGame(){

        gm.ChangeState(GameManager.GameState.ENDGAME);

    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.tag);
        
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
