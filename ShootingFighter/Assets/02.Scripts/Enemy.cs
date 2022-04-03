using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public LayerMask targetLayer;
    public int damage;
    public int score;

    private int _hp;
    public int hp  //멤버프로퍼티
    {
        set
        {
            if (value > 0)
            {

                _hp = value;
            }
            else
            {
                _hp = 0;
                Player.instance.score += score;
                DoDestroyEffect();
                Destroy(gameObject);
            }
            hpSlider.value = (float)_hp / hpMax;
            
        }
        get
        {
            return _hp;
        }
    }
    public int hpMax;
    public Slider hpSlider;
    
    private void Awake()
    {
        hp = hpMax;
    }

    public void DoDestroyEffect()
    {
        GameObject go =Instantiate(destroyEffect, transform.position,Quaternion.identity); //한번만들고 끝나면 지운다. 디스트로이의 오버로드를 사용
        Destroy(go, 3); //3초뒤에 부서진다. 
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //other.gameObject.GetComponent<Player>().hp -= damage;
            Player.instance.hp -= damage;  // <--- instance화 싱글턴 패턴으로 그 객체의 멤버에 직접 접근함.
            Destroy(gameObject);
        }
    }
}
