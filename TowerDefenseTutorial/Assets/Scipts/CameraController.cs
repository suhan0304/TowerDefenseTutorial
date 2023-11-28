using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; //평면으로 카메라가 움직이는 속도
    void Update()
    {
        if(Input.GetKey("w")) //w 입력 시
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //앞 방향으로 이동
            //deltaTime : 프레임에 상관없이 일정한 거리를 이동하도록 설정
            //Space.World : 세계 좌표를 기준으로 이동하도록 설정
        }
        
    }
}
