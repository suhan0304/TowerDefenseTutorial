using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        GameIsOver = false; //게임 시작 시에 게임 오버를 False로 설정
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
        gameOverUI.SetActive(true); //게임 오버 UI 활성화
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
