using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 키보드 화살표 왼쪽, 오른쪽 방향키로 X축으로 움직임
    // 키보드 화살표 위쪽, 아래쪽 방향키로 Z축으로 움직임
    Transform tr;
    //키보드입력에 대한 멤버변수;
    Vector3 move;
    public float speed = 1f;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update() //키입력 Update
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, v); 
    }
    private void FixedUpdate() //출력 FixedUpdate
    {
        tr.Translate(move * speed * Time.fixedDeltaTime);
    }
}
