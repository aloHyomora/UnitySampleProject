using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //나가야한다 벡터 속도필요
    public Vector3 dir =  Vector3.forward; //방향
    public float speed = 5f;
    Transform tr;
    private void Awake() =>  
        tr= GetComponent<Transform>(); //간단히표현할 수 있다.
    
    private void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //enemy만났을 때만 총알 삭제
        GameObject go = other.gameObject; //gameObject ->충돌한 게임오브젝트
        if (go == null) return;
        //레이어체크
        if(go.layer == LayerMask.NameToLayer("Enemy")) //Enemy 체크
        {
            
            go.GetComponent<Enemy>().DoDestroyEffect(); //클래스
            Destroy(go);         //"Enemy"레이어가진 오브젝트 뿌시고
            Destroy(gameObject); //자기자신 뿌시고
        }

    }
}
