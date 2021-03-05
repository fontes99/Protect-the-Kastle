﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_menu : MonoBehaviour
{
    GameManager gm;

    void OnEnable(){
        gm = GameManager.GetInstance();
        Time.timeScale = 0f;
    }

    public void Comecar(){

        gm.ChangeState(GameManager.GameState.GAME);
        Cursor.visible = false;
        Time.timeScale = 1f;

    }

}
