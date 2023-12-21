using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TurretBlueprint
{
    public GameObject prefab; //터렛 프리팹
    public int cost;          //터렛 건설비용

    public GameObject upgradedPrefab; //업그레이드 터렛 프리팹
    public int upgradeCost; //업그레이드 비용
}
