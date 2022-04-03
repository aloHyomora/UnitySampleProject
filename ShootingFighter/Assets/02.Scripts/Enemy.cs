using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public LayerMask targetLayer;
    public int damage;
    public int score;

    private int _hp;
    public int hp  //���������Ƽ
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
        GameObject go =Instantiate(destroyEffect, transform.position,Quaternion.identity); //�ѹ������ ������ �����. ��Ʈ������ �����ε带 ���
        Destroy(go, 3); //3�ʵڿ� �μ�����. 
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //other.gameObject.GetComponent<Player>().hp -= damage;
            Player.instance.hp -= damage;  // <--- instanceȭ �̱��� �������� �� ��ü�� ����� ���� ������.
            Destroy(gameObject);
        }
    }
}
