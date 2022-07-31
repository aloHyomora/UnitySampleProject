using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [HideInInspector]
    public int levelCount, randomLevel, randomValue;

    public List<GameObject> prefabLevels;

    private GameObject firstLevel; //refrence to the level from prefabs 
    [HideInInspector]

    void Start()
    {

        firstLevel = Instantiate(prefabLevels[0]);

    }

    public void RestartGame() // restart button in the game manager
    {

        for (int i = 0; i < prefabLevels.Count; i++)
        {

            if (levelCount == i )
            {

                DestroyPrefab();
                CreatePrefab();

            }
            if (levelCount >= prefabLevels.Count)
            {

                CreatePrefabRandomRestart();

            }
        }
    }

    public void NextLevel() // update the game when clik next button
    {
        for (int i = 1; i < prefabLevels.Count; i++)
        {

            if (levelCount == i && levelCount < prefabLevels.Count + 1)
            {

                DestroyPrefab();

                CreatePrefab();

            }

        }
        if (levelCount >= prefabLevels.Count)
        {
   
            CreatePrefabRandom();

        }

    }

    private void CreatePrefab() // create level from prefab
    {
        Instantiate(prefabLevels[levelCount]);
     
    }

    private void DestroyPrefab()       // destroy level 
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone"); // find all game object with tag clone and destroy them
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
       
    }

    private void CreatePrefabRandom()
    {
        DestroyPrefab();

        Instantiate(prefabLevels[randomLevel]);
        randomValue = randomLevel; // Create Prefab Random Restart 
    
    }


    private void CreatePrefabRandomRestart()
    {
        DestroyPrefab();


        Instantiate(prefabLevels[randomValue]);
       
    }

}

