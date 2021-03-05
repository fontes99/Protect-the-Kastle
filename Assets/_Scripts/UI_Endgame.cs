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

        if(gm.hp < 0)
        {
            message.text = "Game Over";
        }
        else
        {
            message.text = "You Win! The Kastle is safe!";
        }
    }

    public void Voltar(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
