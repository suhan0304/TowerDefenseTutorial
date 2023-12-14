using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; //Static으로 선언하면 메모리 상에 바로 올라가 다른 스크립트에서도 편하게 접근 가능
    public int startMoney = 400; //시작 머니

    void Start()
    {
        Money = startMoney; //게임 시작 시 Money를 시작 머니로 설정    
    }
}
