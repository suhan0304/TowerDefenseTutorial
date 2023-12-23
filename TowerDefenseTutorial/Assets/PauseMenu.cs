using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(ui.activeSelf); //활성화 되어있으면 비활성화, 비활성화 되어있으면 활성화

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//현재 활성화 된 Scene을 다시 로드
    }

    public void Menu()
    {
        Debug.Log("Go to Menu"); //메뉴로 돌아가기
    }
}
