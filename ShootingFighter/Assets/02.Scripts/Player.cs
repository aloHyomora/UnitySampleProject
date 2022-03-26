using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI���� �߰��ؾ� �� namespace
public class Player : MonoBehaviour
{
    #region �̱��� ����
    public static Player instance; //��
    private void Awake()
    {
        instance = this; //��ü �ڱ��ڽ��� �ν��Ͻ��� �־��ָ� 
        hp = hpMax;
        score = 0;
    }
    //�÷��̾� HP �����
    //������Ƽ = ������ �Լ�����\
    private int _hp; //��� ������ �ǹ̷�  _hp, m_hp �� �����
    public int hp  //���������Ƽ
    {
        set
        {
            if (value > 0)
                _hp = value;
            else
            {
                _hp = 0;
                Destroy(gameObject);
            }
            
            hpSlider.value = (float)_hp / hpMax;
            hpText.text = _hp.ToString();
        }
        get
        {
            return _hp;
        }
    } 
    public int hpMax;
    public Slider hpSlider;
    public Text hpText;

    private int _score;
    public int score
    {
        set
        {
            _score = value;
            scoreText.text = _score.ToString();
        }
        get
        {
            return _score;
        }
    }
    public Text scoreText;

    
}
#endregion