using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() //���� ���� UI�� Active �� ����
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //���� ����
    }

    public void Retry()
    {
        //�̸� �Ǵ� �ε����� �ε� �� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //���� �ε� ���� MainScene�� �״�� �ٽ� �ҷ���
    }

    public void Menu()
    {
        Debug.Log("Go to menu.") // Menu ui ���� �� ����
    }
}
