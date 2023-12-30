using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    public void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false; //�����ϸ� �ϴ� ��� ��ư�� ��ȣ�ۿ� �Ұ� (Ŭ���ȵ�)
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName); //������ ���� ������� Fade ȿ�� �ָ鼭 �̵�
    }
}
