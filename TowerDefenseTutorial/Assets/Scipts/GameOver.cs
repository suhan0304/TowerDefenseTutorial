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
    void OnEnable() //게임 오버 UI가 Active 시 실행
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //라운드 설정
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //현재 실행중인 Scene을 재로드
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
