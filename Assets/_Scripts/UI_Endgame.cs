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
        Time.timeScale = 0f;

        if(gm.player_hp <= 0 || gm.kastle_hp <= 0)
        {
            message.text = "GAME OVER";
        }
        else
        {
            message.text = "YOU WIN!!\nThe Kastle is safe!";
        }
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>().Reset();

    }
}
