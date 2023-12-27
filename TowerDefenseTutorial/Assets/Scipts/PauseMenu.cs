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
        ui.SetActive(!ui.activeSelf); //Ȱ��ȭ �Ǿ������� ��Ȱ��ȭ, ��Ȱ��ȭ �Ǿ������� Ȱ��ȭ

        if (ui.activeSelf) //Pasued Menu Ȱ��ȭ
        {
            Time.timeScale = 0f; //�ð� ����� 0���� ����
        }
        else
        {
            Time.timeScale = 1f; //�ð� ����� 1�� �ǵ�����
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //���� �������� Scene�� ��ε�
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
