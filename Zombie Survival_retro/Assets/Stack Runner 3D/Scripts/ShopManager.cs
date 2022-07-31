using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] PlayersModules;
    public PlayerBluePrint[] players;
    public Button buyButton;



    // Start is called before the first frame update
    void Start()
    {
        foreach(PlayerBluePrint player in players)
        {
            if (player.price == 0)
                player.isLocked = true;
            else
                player.isLocked = PlayerPrefs.GetInt(player.name, 0) == 0 ? false : true;
        }

        currentPlayerIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject player in PlayersModules)
        {
            player.SetActive(false);
        }
        PlayersModules[currentPlayerIndex].SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUi();
    }
    public void Next()
    {
        PlayersModules[currentPlayerIndex].SetActive(false);
        currentPlayerIndex++;

        if (currentPlayerIndex == PlayersModules.Length)
               currentPlayerIndex = 0;



        PlayersModules[currentPlayerIndex].SetActive(true);
        PlayerBluePrint p = players[currentPlayerIndex];
        if (!p.isLocked)
            return;
        PlayerPrefs.SetInt("SelectedChar", currentPlayerIndex);

    }

    public void Previous()
    {
        PlayersModules[currentPlayerIndex].SetActive(false);
        currentPlayerIndex--;

        if (currentPlayerIndex == -1)
            currentPlayerIndex = PlayersModules.Length-1;



        PlayersModules[currentPlayerIndex].SetActive(true);
        PlayerBluePrint p = players[currentPlayerIndex];
        if (!p.isLocked)
            return;
        PlayerPrefs.SetInt("SelectedChar", currentPlayerIndex);

    }

    public void UpdateUi()
    {
        PlayerBluePrint p = players[currentPlayerIndex];
        if (p.isLocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "Buy-" + p.price;
            if (p.price < PlayerPrefs.GetInt("score", GameManager.instance.score))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }

    public void UnlockPlayer()
    {
        PlayerBluePrint p = players[currentPlayerIndex];
        PlayerPrefs.SetInt(p.name, 1);
        PlayerPrefs.SetInt("SelectedChar", currentPlayerIndex);
        p.isLocked = true;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) - p.price);
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
}
