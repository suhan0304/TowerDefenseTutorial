using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false; 
    1
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
        Debug.Log("Game Over!"); //게임 종료
    }
}
