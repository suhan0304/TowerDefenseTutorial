using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TurretBlueprint
{
    public GameObject prefab; //�ͷ� ������
    public int cost;          //�ͷ� �Ǽ����

    public GameObject upgradedPrefab; //���׷��̵� �ͷ� ������
    public int upgradeCost; //���׷��̵� ���
}
