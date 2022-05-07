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

    public void Hit(HitType hitType)  // Good �̻� ���� ����, ��ƮŸ�� �˾� UI
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
        tr.Translate(Vector2.down * speed * Time.fixedDeltaTime); // ��Ʈ���� ��� �Ʒ��� ��������.
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