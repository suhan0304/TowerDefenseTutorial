using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnrock = 2;

    public SceneFader sceneFader;
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnrock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnrock);
        sceneFader.FadeTo(menuSceneName);
    }
}
