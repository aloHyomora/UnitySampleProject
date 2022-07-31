using UnityEngine;

public class Diamond : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)       // when the daimond collided with the riding boat destroy diamond
    {
        if (other.gameObject.tag == "RidingBoat")
        {

            Destroy(this.gameObject);

            
        }


    }

}
