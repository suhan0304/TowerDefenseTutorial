using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; //속도

    public int health = 100; //몬스터 초기 체력

    public int value = 50; //몬스터를 죽일 시 플레이어에게 주어질 돈

    private Transform target; //목표 방향
    private int wavepointIndex = 0;//현재 목표로하는 웨이포인트 인덱스

    private void Start()
    {
        //WayPoints의 points를 static으로 선언해놨기 때문에 바로 불러올 수 있다.
        //points를 싱글톤 디자인 패턴으로 사용하는 모습
        target = WayPoints.points[0]; 
    }

    public void TakeDamage(int amount)
    {
        health -= amount; //amount 만큼 체력 감소

        if(health <= 0)
        {
            Die(); // 에너미 사망 메서드
        }
    }

    void Die()
    {
        PlayerStats.Money += value; //플레이어에게 돈 지급
        Destroy(gameObject);
    }

    void Update()
    {
        //이동해야 할 방향 ( 목표 위치 - 내 위치  )
        Vector3 dir = target.position - transform.position;

        //방향 벡터로 스피드 만큼 이동
        //방향을 단위벡터로 바꾸기 위해 normalized 진행 후 speed를 곱한만큼 진행 (프레임-시간 보정으로 deltaTime을 사용)
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //World Space에서 이동


        //웨이포인트 도착 시 다음 웨이포인트로 변경
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) // 웨이 포인트와 에너미의 거리가 0.4 이하면 다음 웨이 포인트로
        {
            GetNextWayPoint(); //다음 웨이포인트를 타겟으로 변경
        } 
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1) //만약 가지고 있는 모든 웨이포인트를 방문 > 도착 지점 도달
        {
            EndPath();
            return; //아래의 다음 웨이포인트 가져오는 것을 하지 않고 바로 종료
        }

        wavepointIndex++; //다음 웨이포인트 인덱스
        target = WayPoints.points[wavepointIndex]; //다음 인덱스의 웨이포인트 오브젝트를 받아온다.
    }

    void EndPath() //경로의 끝(목표)에 도달
    {
        Destroy(gameObject); //도착지점 도착 시 오브젝트 파괴
        PlayerStats.Lives--; // lives를 1 감소
    }
}