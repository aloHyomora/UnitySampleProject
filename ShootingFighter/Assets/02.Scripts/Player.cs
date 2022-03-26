using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI사용시 추가해야 할 namespace
public class Player : MonoBehaviour
{
    #region 싱글톤 패턴
    public static Player instance; //게
    private void Awake()
    {
        instance = this; //객체 자기자신을 인스턴스에 넣어주면 
        hp = hpMax;
        score = 0;
    }
    //플레이어 HP 만들기
    //프로퍼티 = 변수와 함수사이\
    private int _hp; //멤버 변수란 의미로  _hp, m_hp 로 사용함
    public int hp  //멤버프로퍼티
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