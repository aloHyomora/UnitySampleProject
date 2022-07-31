using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] Players;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject player in Players)
        {
            player.SetActive(false);
        }
        Players[currentPlayerIndex].SetActive(true);


    }
}
