using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f; //평면으로 카메라가 움직이는 속도
    public float panBorderThickness = 10; //화면을 움직일 마우스 테두리 위치 굵기
    
    public float scrollSpeed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //ESC 키를 눌러 doMovement를 부울을 변경할 수 있다.
            doMovement = !doMovement;         //ESC 키를 눌러 카메라 움직임을 껐다 켰다 할 수 있다.

        if (!doMovement) //doMovement가 False이면 카메라를 움직이지 않는다.
            return;

        //카메라 이동 제어
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) //w 입력 시 or 마우스가 화면의 상단 (y 좌표 - panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //앞 방향으로 이동
            //deltaTime : 프레임에 상관없이 일정한 거리를 이동하도록 설정
            //Space.World : 세계 좌표를 기준으로 이동하도록 설정 - 회전을 무시하고 이동
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) //s 입력 시 or 마우스가 화면의 하단 (panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); 
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) //d 입력 시 or 마우스가 화면의 오른쪽 (x 좌표 - panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); 
        } 
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) //a 입력 시 or 마우스가 화면의 왼쪽 (panBorderThickness) 바깥쪽에 있을 때
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); 
        }

        //카메라 높낮이 및 회전 제어
        //스크롤은 GetKey처럼 누름, 안누름과 같이 2가지 경우가 아니라 속도를 값으로 반환한다. (아래 방향은 음수, 위 방향은 양수)
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Debug.Log(scroll);

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime; //휠 반환 값 * 속도 * 프레임-시간 보정

        transform.position = pos; //위치 조정
    }
}
