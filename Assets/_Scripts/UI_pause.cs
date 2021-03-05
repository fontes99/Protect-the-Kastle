using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_pause : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
    
    public void Retornar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        Cursor.visible = false;
    }

    public void Inicio()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
