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

        if(PlayerStats.Lives <= 0) //�÷��̾� ü���� 0 ����
        {
            EndGame(); //���� ���� �Լ�
        }
    }


    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!"); //���� ����
    }
}
