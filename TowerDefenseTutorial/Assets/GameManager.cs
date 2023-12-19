using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if(PlayerStats.Lives <= 0) //플레이어 체력이 0 이하
        {
            EndGame(); //게임 종료 함수
        }
    }


    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
