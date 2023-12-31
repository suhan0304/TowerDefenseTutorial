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
        GameIsOver = false; //���� ���� �ÿ� ���� ������ False�� ����
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if(PlayerStats.Lives <= 0) //�÷��̾� ü���� 0 ����
        {
            EndGame(); //���� ���� �Լ�
        }
    }

    void EndGame() 
    {
        GameIsOver = true;
        gameOverUI.SetActive(true); //���� ���� UI Ȱ��ȭ
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
