using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount]; //wayPoint ������ŭ �迭 �ʱ�ȭ
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); //transform�� ������ŭ �ڳฦ ������ points �迭�� �Ҵ�����ش�.
        }
    }
}
