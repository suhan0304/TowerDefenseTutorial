using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() //���� ���� UI�� Active �� ����
    {
        StartCoroutine(AnimeText());
    }

    IEnumerator AnimeText()
    {
        roundsText.text = "0";
        int round = 0; 

        yield return new WaitForSeconds(.7f); //Fade ȿ�� ���ð�

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }

    }
}
