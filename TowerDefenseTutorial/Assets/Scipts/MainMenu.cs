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
        SceneManager.LoadScene(levelToLoad); //MainLevel �̸��� ���� �ε�
    }

    public void Quit()
    {
        Debug.Log("Exiting..."); //����Ƽ �����Ϳ��� ������ ���� Ȯ���� �� �� : ������� Ȯ��
        Application.Quit(); 
    }
}
