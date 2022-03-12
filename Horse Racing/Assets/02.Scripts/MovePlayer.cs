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
    public bool doMove; //�޸��� �� �� doMove�� true�� �ٲ�

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
        //Random random = new Random();  ����ũ�μ���Ʈ ������
        float moveSpeed = Random.Range(minSpeed, maxSpeed);
        move = dir * moveSpeed * Time.fixedDeltaTime;
        tr.Translate(move); //? �����̰�  ���ϴ°���
        distance += move.z; 
    }
}