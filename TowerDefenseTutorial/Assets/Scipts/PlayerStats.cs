using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; //Static으로 선언하면 메모리 상에 바로 올라가 다른 스크립트에서도 편하게 접근 가능
    public int startMoney = 400; //시작 머니

    public static int Lives; //현재 생명 값
    public int startLives = 20; //초기화 값

    public static int Rounds = 0;

    void Start()
    {
        Money = startMoney; //게임 시작 시 Money를 시작 머니로 설정    
        Lives = startLives;

        Rounds = 0;
    }
}
