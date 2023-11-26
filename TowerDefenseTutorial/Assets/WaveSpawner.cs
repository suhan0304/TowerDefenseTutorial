using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint; //몬스터 스폰 위치

    public float timeBetweenWaves = 5f; //웨이브 사이 대기 시간
    private float countdown = 2f;

    private int waveNumber = 1;// 웨이브 번호

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
        for (int i = 0; i < waveNumber; i++) //웨이브 레벨만큼 몬스터 소한
        {
            SpawnEnemy();
        }
        waveNumber++; //웨이브가 올때마다 레벨업
    }

    void SpawnEnemy()
    {
        //미리 지정해둔 스폰 포인트에서 몬스터를 복사해서 소환
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
