
using UnityEngine;

public class RidingBoat : MonoBehaviour
{

    private PlayerController playerController;
    

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void IncerementBoatVolume(float value)         // increment boat volume
    {

        if (value < 0)
        {

            playerController.DropBoats(this);
          

        }
        else    // calculate the position and the scale of the boat 
        {
            int boatCount = playerController.boats.Count; 
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (boatCount - 1) + -0.25f* value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * value, 0.5f*value*transform.localScale.y, 0.5f*value);
        }
    }
}
