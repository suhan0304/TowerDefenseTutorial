using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() //게임 오버 UI가 Active 시 실행
    {
        roundsText.text = PlayerStats.Rounds.ToString(); //라운드 설정
    }
}
