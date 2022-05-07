using UnityEngine;

[CreateAssetMenu(menuName = "Hit Judge Info")]
public class HitJudgeInfo : ScriptableObject 
{
    [Header("____Bad 판정 높이____")] //보기좋다
    public float hitJudgeHeight_Bad;
    [Header("____Miss 판정 높이____")]
    public float hitJudgeHeight_Miss;
    [Header("Good 판정 높이")]
    public float hitJudgeHeight_Good;
    [Header("Great 판정 높이")]
    public float hitJudgeHeight_Great;
    [Header("Cool 판정 높이")]
    public float hitJudgeHeight_Cool;
}
