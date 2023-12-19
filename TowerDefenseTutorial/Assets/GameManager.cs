using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public GameObject gameOverUI;

    void Update()
    {
        if (gameEnded)
            return;

        if(PlayerStats.Lives <= 0) //플레이어 체력이 0 이하
        {
            EndGame(); //게임 종료 함수
        }
    }


    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
