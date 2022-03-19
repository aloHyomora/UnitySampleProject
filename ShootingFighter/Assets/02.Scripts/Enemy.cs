using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //충돌 이벤트 함수 
{
    /* private void OnCollisionEnter(Collision collision)//매개변수 Collision, 유니티 엔진이 계산해서collision에 해당하는 값 넘겨줌.
     {
         if (collision.gameObject == null) return;

         Debug.Log($"collisioned! { collision.gameObject.name}");
     }
     private void OnTriggerEnter(Collider other)
     {
         Debug.Log($"triggered! { other.gameObject.name}");
     }*/
    public GameObject destroyEffect;



    public void DoDestroyEffect()
    {
        GameObject go =Instantiate(destroyEffect, transform.position,Quaternion.identity); //한번만들고 끝나면 지운다. 디스트로이의 오버로드를 사용
        Destroy(go, 3); //3초뒤에 부서진다. 
    }

    private void OnTriggerEnter(Collider other)
    {        
        Destroy(other.gameObject);
    }
}
