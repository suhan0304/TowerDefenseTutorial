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
            levelButtons[i].interactable = false; //시작하면 일단 모든 버튼은 상호작용 불가 (클릭안됨)
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName); //선택한 레벨 장면으로 Fade 효과 주면서 이동
    }
}
