using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEable() //���� ���� UI�� Active �� ����
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //���� ����

    }
}
