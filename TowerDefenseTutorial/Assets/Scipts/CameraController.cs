using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; //평면으로 카메라가 움직이는 속도
    public float panBorderThickness = 10; //화면을 움직일 마우스 테두리 위치 굵기
    void Update()
    {
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) //w 입력 시 or 마우스가 화면의 상단 (y 좌표 - panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //앞 방향으로 이동
            //deltaTime : 프레임에 상관없이 일정한 거리를 이동하도록 설정
            //Space.World : 세계 좌표를 기준으로 이동하도록 설정 - 회전을 무시하고 이동
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) //s 입력 시 or 마우스가 화면의 하단 (panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) //d 입력 시 or 마우스가 화면의 오른쪽 (x 좌표 - panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); 
        } 
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) //a 입력 시 or 마우스가 화면의 왼쪽 (panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); 
        }

    }
}
