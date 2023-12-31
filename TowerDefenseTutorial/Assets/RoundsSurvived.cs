using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() //게임 오버 UI가 Active 시 실행
    {
        StartCoroutine(AnimeText());
    }

    IEnumerator AnimeText()
    {
        roundsText.text = "0";
        int round = 0; 

        yield return new WaitForSeconds(.7f); //Fade 효과 대기시간

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }

    }
}
