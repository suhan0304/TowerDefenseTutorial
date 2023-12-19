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

        if(PlayerStats.Lives <= 0) //�÷��̾� ü���� 0 ����
        {
            EndGame(); //���� ���� �Լ�
        }
    }


    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
