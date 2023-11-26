using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform ememyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private void Update()
    {
        if (countdown <= 0f) //카운트다운이 0 보다 작아지먄 Spawn Wave 실행
        {
            SpawnWave();
            countdown = timeBetweenWaves;//카운트 다운을 중간 시간으로 초기화
        }

        //deltaTime//마지막 프레임을 그린 후 경과한 시간
        countdown -= Time.deltaTime; //시간을 계속 줄인다.
    }

    void SpawnWave()
    {
        Debug.Log("Wave Incoming!");
    }
}
