using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteHitter : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private HitJudgeInfo hitJudgeInfo; // 참조
    [SerializeField] private LayerMask noteLayer;

    private SpriteRenderer icon; 
    [SerializeField] private Color pressedColor;
    private Color originalColor; // 색깔을 바꾸는데 원래 색을 저장할 변수

    private void Awake()
    {
        icon = GetComponent<SpriteRenderer>();
        originalColor = icon.color;
    }
    private void Update()
    {
        // 키입력 들어올 때 노트 히트
        if (Input.GetKeyDown(keyCode))
            TryHitNote();

        // 키가 눌려져 있으면 색 바꿈
        if(Input.GetKey(keyCode))
            ChangeColor();
    }
    private void ChangeColor() =>
            icon.color = pressedColor;    
    private void RollbackColor() =>
            icon.color = originalColor;
    
    private bool TryHitNote() // 성공할수도실패할수도
    {
        HitType hitType = HitType.Bad;

        List<Collider2D> overlaps = 
            Physics2D.OverlapBoxAll(transform.position, 
                                    new Vector2(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Bad),
                                    0, noteLayer).ToList();

        if(overlaps.Count > 0) // 노트가 들어왔다는 의미 , 떨어진 거리에서 젤 먼것이 첫번째요소가 되어야함
        {
            overlaps.OrderBy(x => Mathf.Abs(transform.position.y - x.transform.position.y));
            // x == overlaps의 요소
            // 람다 표현 : x는 매개변수이고 x라는 매개변수를 사용한 람다식 -> 델리게이트를만들겠다.
            // 델리게이트는 대리자 함수는 아니고 함수기능할수있도록 구현할 수 있도록 한다.
            // 메소드 : 함수 중에서 객체 단위로 호출되는것, NoteHitter스크립트에서 TryHitNote()는 멤버이고 메소드
            // 함수 : 특정한 기능을 수행
            float distance = Mathf.Abs(transform.position.y - overlaps[0].transform.position.y);

            if (distance < hitJudgeInfo.hitJudgeHeight_Cool)       //제일 정확한 COOL부터 찾음
                hitType = HitType.Cool;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Great)
                hitType = HitType.Great;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Good)
                hitType = HitType.Good;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Miss)
                hitType = HitType.Miss;
            else
                hitType = HitType.Bad;

            overlaps[0].GetComponent<Note>().Hit(hitType);
            overlaps[0].gameObject.SetActive(false);
            return true; // 노트 들어왔으니까
        }
        return false; // 노트 안들어옴.
    }

    private void OnDrawGizmos()
    {
        // Bad 판정 범위 기즈모
        Gizmos.color = Color.gray; 
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Bad,0));
        // Miss 판정 범위 기즈모
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Miss, 0));
        // Good 판정 범위 기즈모
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Good, 0));
        // Great 판정 범위 기즈모
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Great, 0));
        // Cool 판정 범위 기즈모
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Cool, 0));
    }
}
