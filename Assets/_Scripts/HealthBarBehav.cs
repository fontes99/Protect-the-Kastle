using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehav : MonoBehaviour
{

    public Slider slider;
    GameManager gm;

    // ----------------------- 

    void Start() {
        gm = GameManager.GetInstance();
    }

    public void SetHealth(int health){
        slider.value = health;
        gm.hp = health;
    }

    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }

}
