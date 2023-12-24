using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string MenuToLoad = "MainMenu";
    public static string levelToLoad = "MainLevel";

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad); //MainLevel 이름의 씬을 로드
    }

    public void Quit()
    {
        Debug.Log("Exiting..."); //유니티 에디터에선 실제로 종료 확인이 안 됨 : 출력으로 확인
        Application.Quit(); 
    }
}
