using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; //Static���� �����ϸ� �޸� �� �ٷ� �ö� �ٸ� ��ũ��Ʈ������ ���ϰ� ���� ����
    public int startMoney = 400; //���� �Ӵ�

    public static int Lives; //���� ���� ��
    public static int startLives = 20; //�ʱ�ȭ ��
    void Start()
    {
        Money = startMoney; //���� ���� �� Money�� ���� �ӴϷ� ����    
        Lives = startLives;
    }
}
