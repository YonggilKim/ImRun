using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동 속도
    private bool rightPress = false;
    private bool leftPress = false;
    private void Update()
    {
        // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
        if (rightPress == true)
        { 
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            PlayerController.instance.RotateChar(0);// 케릭터를 오른쪽 방향으로 회전
        }
        if (leftPress == true)
        { 
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            PlayerController.instance.RotateChar(180);//케릭터를 왼쪽방향으로 회전
        }
        transform.Translate(Vector3.left * speed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 50);
    }

    public void OnRightPress()
    {
        PlayerController.instance.isLeftty = false;
        rightPress = true;
        PlayerController.instance.ChangeWalkingState(true);

    }
    public void OnRigtMouseUP()
    {
        rightPress = false;
        PlayerController.instance.ChangeWalkingState(false);

    }
    public void OnLeftPress()
    {
        PlayerController.instance.isLeftty = true;
        PlayerController.instance.ChangeWalkingState(true);
        leftPress = true;
    }
    public void OnLeftMouseUP()
    {
        leftPress = false;
        PlayerController.instance.ChangeWalkingState(false);

    }
}