using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelToUnrock = 2;

    public SceneFader sceneFader;

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
        Debug.Log("LEVEL WON!");
        PlayerPrefs.SetInt("levelReached", levelToUnrock);
        sceneFader.FadeTo(nextLevel);
    }
}
