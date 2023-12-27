using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;
    void OnEnable() //���� ���� UI�� Active �� ����
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //���� ����
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //���� �������� Scene�� ��ε�
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
