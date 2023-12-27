using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Paused");
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf); //활성화 되어있으면 비활성화, 비활성화 되어있으면 활성화

        if (ui.activeSelf) //Pasued Menu 활성화
        {
            Time.timeScale = 0f; //시간 배속을 0으로 설정
        }
        else
        {
            Time.timeScale = 1f; //시간 배속을 1로 되돌리기
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //현재 실행중인 Scene을 재로드
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
