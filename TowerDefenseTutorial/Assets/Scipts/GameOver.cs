using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //현재 실행중인 Scene을 재로드
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
