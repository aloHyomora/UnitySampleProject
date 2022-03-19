using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour //EnemyMove �ϱ� �����θ� �ۼ�
{
    public Vector3 dir = Vector3.back; //����
    public float speed = 1f;
    Transform tr;
    private void Awake() =>
        tr = GetComponent<Transform>(); //������ǥ���� �� �ִ�.

    private void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }
}
