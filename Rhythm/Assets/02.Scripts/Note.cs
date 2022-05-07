using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    
    public KeyCode keyCode;
    public float speed = 1f ;
    Transform tr;

    //===============================================
    //****************  Public Methods **************
    //===============================================

    public void Hit(HitType hitType)  // Good 이상 점수 증가, 히트타입 팝업 UI
    {
        switch (hitType)
        {
            case HitType.Bad:
                break;
            case HitType.Miss:
                break;
            case HitType.Good:
                break;
            case HitType.Great:
                break;
            case HitType.Cool:
                break;
            default:
                break;
        }
    }

    //===============================================
    //****************  Private Methods **************
    //===============================================
    private void Awake()
    {
        tr= GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        tr.Translate(Vector2.down * speed * Time.fixedDeltaTime); // 노트들은 계속 아래로 떨어진다.
    }
    
}
public enum HitType
{
    Bad,
    Miss,
    Good,
    Great,
    Cool,
}