using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Endgame : MonoBehaviour
{
    public Text message;

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        Cursor.visible = true;

        if(gm.hp <= 0)
        {
            message.text = "GAME OVER";
        }
        else
        {
            message.text = "YOU WIN! The Kastle is safe!";
        }
    }

    public void Voltar(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
