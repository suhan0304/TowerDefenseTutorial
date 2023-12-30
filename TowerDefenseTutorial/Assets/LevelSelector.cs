using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;


    public void Select(string levelName)
    {
        fader.FadeTo(levelName); //선택한 레벨 장면으로 Fade 효과 주면서 이동
    }
}
