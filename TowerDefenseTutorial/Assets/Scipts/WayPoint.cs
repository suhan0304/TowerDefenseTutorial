using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount]; //wayPoint 갯수만큼 배열 초기화
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); //transform의 갯수만큼 자녀를 가져와 points 배열에 할당시켜준다.
        }
    }
}