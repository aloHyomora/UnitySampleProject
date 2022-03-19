using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour //EnemyMove 니깐 움직인만 작성
{
    public Vector3 dir = Vector3.back; //방향
    public float speed = 1f;
    Transform tr;
    private void Awake() =>
        tr = GetComponent<Transform>(); //간단히표현할 수 있다.

    private void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }
}
