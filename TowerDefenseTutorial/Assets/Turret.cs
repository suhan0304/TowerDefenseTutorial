using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target; // 공격할목표 오브젝트
    public float range = 15f; // 사거리는 15로 설정

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected() //기즈모를 그려주는 유니티 함수
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); //내 위치를 기준으로 range를 반지름을 구를 그려줌
    }
}
