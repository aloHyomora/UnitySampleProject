using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //�浹 �̺�Ʈ �Լ� 
{
    /* private void OnCollisionEnter(Collision collision)//�Ű����� Collision, ����Ƽ ������ ����ؼ�collision�� �ش��ϴ� �� �Ѱ���.
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
        GameObject go =Instantiate(destroyEffect, transform.position,Quaternion.identity); //�ѹ������ ������ �����. ��Ʈ������ �����ε带 ���
        Destroy(go, 3); //3�ʵڿ� �μ�����. 
    }

    private void OnTriggerEnter(Collider other)
    {        
        Destroy(other.gameObject);
    }
}
