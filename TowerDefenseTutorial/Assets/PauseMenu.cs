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
        ui.SetActive(ui.activeSelf); //Ȱ��ȭ �Ǿ������� ��Ȱ��ȭ, ��Ȱ��ȭ �Ǿ������� Ȱ��ȭ

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//���� Ȱ��ȭ �� Scene�� �ٽ� �ε�
    }

    public void Menu()
    {
        Debug.Log("Go to Menu"); //�޴��� ���ư���
    }
}
