using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Transform tr;
    public float distance;
    public Vector3 dir = Vector3.forward;
    public float minSpeed;
    public float maxSpeed;
    public bool doMove; //달리게 할 때 doMove를 true로 바꿈

    Vector3 move;
    // Start is called before the first frame update
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (doMove)
            Move();
    }

    private void Move()
    {
        //Random random = new Random();  마이크로소프트 지원용
        float moveSpeed = Random.Range(minSpeed, maxSpeed);
        move = dir * moveSpeed * Time.fixedDeltaTime;
        tr.Translate(move); //? 뭐야이거  왜하는거지
        distance += move.z; 
    }
}