using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    public float limitX, runningSpeed, xSpeed;

    public GameObject ridingBoatPrefab;
    public List<RidingBoat> boats;    // list of Boat

    public GameObject diamond;     // reference to the diamond

    public Animator anim; // reference to the animator

    public Rigidbody m_Rigidbody;  // reference to the rigidbody

    public bool isPlayerControlActive=true;    

    public AudioSource winMusic, CoinSound, BoatSound,DefeatSound;     // reference to the Sounds
    public ParticleSystem conffeti;

    

    public void AddBoatStart()   // add boat method
    {
        IncrementBoatVolume(1f);
        //anim.SetTrigger("idle");
    }
   
    void FixedUpdate()
    {
        if (isPlayerControlActive)
        {
            PlayerControl();
        }
           
        
        
    }

    private void PlayerControl()        // control the player
    {
        float newX;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
        
            touchXDelta = Input.GetTouch(0).deltaPosition.x ;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);


       
        

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Add Boat")      // when the player colided with tho boat
        {
            BoatSound.Play();           // play sound
            IncrementBoatVolume(1f);   // increase Boat Volume By 1
            Destroy(other.gameObject);    // destroy the boat
            
        }
        if (other.tag == "Trap" || other.tag == "Wall")   // when the player colided with the Obstacles
        {
            IncrementBoatVolume(-1f);   // decrease boat volume by 1
            if (boats.Count == 0)
            {
                DefeatSound.Play();
                GameManager.instance.LoseGame();   // if the boat count equal O lose the game
                
            }
        }

        if (other.tag == "FinishLevel")      
        {
            GameManager.instance.isLevelFinish = true;
            GameManager.instance.LevelTotalPoint(boats.Count);
           
        }

        if (other.tag=="FinishWall")
        {
            IncrementBoatVolume(-1f);
            if ( boats.Count <= 0)
            {
                GameManager.instance.FinishLevel();

            }
        }

        if (other.tag == "Diamond")     // when the player collided with the diamond
        {
            CoinSound.Play();                   // play sound
            GameManager.instance.AddPoint(1);

            BoostPlayerSpeed();        // increase player speed
        }
    }

    public void IncrementBoatVolume(float value)       // increment boat volume method
    {
      
            if (value>0)
            {
                CreateBoat(value);
            }
      
        else if(value<0 && boats.Count!=0)
        {
            boats[boats.Count - 1].IncerementBoatVolume(value);
            BoatSound.Play();
         
        }

    }

    public void CreateBoat(float value)      // creat boat method
    {
        RidingBoat createdBoat = Instantiate(ridingBoatPrefab, transform).GetComponent<RidingBoat>();    // instantiat the boat for player

        boats.Add(createdBoat);
        createdBoat.IncerementBoatVolume(value);
     
    }

    public void DropBoats(RidingBoat boat) // when remove tho boat
    {
        boats.Remove(boat);
        boat.gameObject.transform.parent = null;

    }


    public void DestroyBoats()
    {
         GameObject[] boats = GameObject.FindGameObjectsWithTag("RidingBoat");
        foreach (var boat in boats)
        {
            Destroy(boat);
        }
    }

    public void PlayerStartPosition()
    {
      
        transform.localPosition = new Vector3(0, 0.75f, -23.7999992f);
        IncrementBoatVolume(1f);
        limitX = 3;
        anim.SetTrigger("idle");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1f);
    }


    public void BoostPlayerSpeed()         // boost player speed methode
    {
        runningSpeed = 13;
        StartCoroutine(NormalPlayerSpeed());
    }

    IEnumerator NormalPlayerSpeed()                     // return to the normal speed
    {
        yield return new WaitForSecondsRealtime(2f);
        runningSpeed = 10;
    }
  
    public void PlayerControlActiveFalse()
    {
        isPlayerControlActive = false;
    }

    public void PlayerControlActiveTrue()
    {
        isPlayerControlActive = true;
    }


    public void WinAnimation()              // win condition
    {
        winMusic.Play();
        conffeti.gameObject.SetActive(true);
        conffeti.Play();
        anim.SetTrigger("Win");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 100f);
    }
    


}
 