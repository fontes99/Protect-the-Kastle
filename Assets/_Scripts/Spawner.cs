using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject archer, balista, meteor, dragon, soldier;

    float archer_spawnRate = 0.1f;
    float balista_spawnRate = 0.1f; 
    float meteor_spawnRate = 0.075f;
    float dragon_spawnRate = 0.05f;
    float soldier_spawnRate = 0.2f;

    float nextArcherSpawn = 0;
    float nextBalistaSpawn = 0;
    float nextMeteorSpawn = 0;
    float nextDragonSpawn = 0;
    float nextSoldierSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextArcherSpawn = Time.time + 1f/archer_spawnRate;
        nextBalistaSpawn = Time.time + 1f/balista_spawnRate;
        nextMeteorSpawn = Time.time + 1f/meteor_spawnRate;
        nextDragonSpawn = Time.time + 1f/dragon_spawnRate;
        nextSoldierSpawn = Time.time + 1f/soldier_spawnRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnArcher();
        SpawnBalista();
        SpawnMeteor();
        SpawnDragon();
        SpawnSoldier();
    }

    public void Reset(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        GameObject.FindGameObjectWithTag("timer").GetComponent<TimerBehav>().Reset();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ResetPlayer();
        GameObject.FindGameObjectWithTag("Kastle").GetComponent<KastleBehav>().Reset();
    }

    void SpawnArcher(){
        if (Time.time >= nextArcherSpawn) {
            Instantiate(archer, new Vector3(Random.Range(-6f, 6f), transform.position.y,0f), Quaternion.identity, transform);
            nextArcherSpawn = Time.time + 1f/archer_spawnRate;
        }
    }
    
    void SpawnBalista(){
        if (Time.time >= nextBalistaSpawn) {
            Instantiate(balista, new Vector3(Random.Range(-6f, 6f), transform.position.y,0f), Quaternion.identity, transform);
            nextBalistaSpawn = Time.time + 1f/balista_spawnRate;
        }
    }
    
    void SpawnMeteor(){
        if (Time.time >= nextMeteorSpawn) {
            Instantiate(meteor, new Vector3(Random.Range(-6f, 6f), transform.position.y,0f), Quaternion.identity, transform);
            nextMeteorSpawn = Time.time + 1f/meteor_spawnRate;
        }
    }
    
    void SpawnDragon(){
        if (Time.time >= nextDragonSpawn) {
            Instantiate(dragon, new Vector3(Random.Range(-6f, 6f), transform.position.y,0f), Quaternion.identity, transform);
            nextDragonSpawn = Time.time + 1f/dragon_spawnRate;
        }
    }
    
    void SpawnSoldier(){
        if (Time.time >= nextSoldierSpawn) {
            Instantiate(soldier, new Vector3(Random.Range(-6f, 6f), transform.position.y,0f), Quaternion.identity, transform);
            nextSoldierSpawn = Time.time + 1f/soldier_spawnRate;
        }
    }
}
