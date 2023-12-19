using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() //게임 오버 UI가 Active 시 실행
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //라운드 설정
    }

    public void Retry()
    {
        //이름 또는 인덱스로 로드 씬 가능
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //현재 로드 중인 MainScene을 그대로 다시 불러옴
    }

    public void Menu()
    {
        Debug.Log("Go to menu.") // Menu ui 구현 후 연결
    }
}
