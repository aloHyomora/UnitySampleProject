using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance; //싱글턴패턴 DicePlayManager에서 참조
    private void Awake()
    {
        instance = this;
    }
    public void Move(Vector3 target) =>
        transform.position = target;
    
}