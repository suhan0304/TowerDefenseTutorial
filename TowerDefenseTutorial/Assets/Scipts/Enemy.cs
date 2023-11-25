using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; //속도

    private Transform target; //목표 방향
    private int wavepointIndex = 0;//현재 목표로하는 웨이포인트 인덱스

    private void Start()
    {
        //WayPoints의 points를 static으로 선언해놨기 때문에 바로 불러올 수 있다.
        //points를 싱글톤 디자인 패턴으로 사용하는 모습
        target = WayPoints.points[0]; 
    }

    void Update()
    {
        //이동해야 할 방향 ( 목표 위치 - 내 위치  )
        Vector3 dir = target.position - transform.position;

        //방향 벡터로 스피드 만큼 이동
        //방향을 단위벡터로 바꾸기 위해 normalized 진행 후 speed를 곱한만큼 진행 (프레임-시간 보정으로 deltaTime을 사용)
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //World Space에서 이동
        

    }
}
