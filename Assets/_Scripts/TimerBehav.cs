using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBehav : MonoBehaviour
{

    int maxTime = 1200;
    public int currentTime;

    public float TimeDropRate = 10f;
    float nextTimeDrop = 0f;

    public HealthBarBehav TimeBar;

    GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        TimeBar.SetMaxHealth(maxTime);

        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= nextTimeDrop) {
            currentTime -= 1;
            TimeBar.SetHealth(currentTime);
            nextTimeDrop = Time.time + 1f/TimeDropRate;
        }

        if (currentTime <= 0) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }

    }

    public void Reset(){
        currentTime = maxTime;
        TimeBar.SetHealth(maxTime);
    }
}
