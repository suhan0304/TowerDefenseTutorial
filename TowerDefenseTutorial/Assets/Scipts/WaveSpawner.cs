using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform enemyPrefab;

    public Transform spawnPoint; //몬스터 스폰 위치

    public float timeBetweenWaves = 5.5f; //웨이브 사이 대기 시간
    private float countdown = 2f;
    
    public Text waveCountdownText;

    private int waveIndex = 0; // 웨이브 번호

    private void Update()
    {
        if (EnemiesAlive >0)
        {
            return;
        }

        if (countdown <= 0f) //카운트다운이 0 보다 작아지먄 Spawn Wave 실행
        {
        
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; //카운트 다운을 중간 시간으로 초기화
        }

        //deltaTime//마지막 프레임을 그린 후 경과한 시간
        countdown -= Time.deltaTime; //시간을 계속 줄인다.
        
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); //카운트 다운이 0보다 낮아지지 않도록 설정

        waveCountdownText.text = string.Format("{0:00.00}", countdown); //출력 형식을 지정

        //waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() //코루틴
    {
        waveIndex++;//웨이브가 올때마다 레벨업
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)  //웨이브 레벨만큼 몬스터 소한
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        //미리 지정해둔 스폰 포인트에서 몬스터를 복사해서 소환
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}