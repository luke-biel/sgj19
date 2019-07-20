using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    List<Player> players;
    Player currentPlayer;
    InputField inputField;
    void Start()
    {
        players = new List<Player>();
        inputField = gameObject.GetComponentInChildren<InputField>();
        currentPlayer = new Player()
        {
            color = Color.blue,
            name = "New Player",
            points = 0

        };
        players.Add(currentPlayer);
        PlayerChanged();
    }

    public void AddPlayer(bool positive)
    {
        if(positive)
        {
            Color color = new Color(
                         (float)Random.Range(0f, 1f),
                         (float)Random.Range(0f, 1f),
                         (float)Random.Range(0f, 1f));
            currentPlayer = new Player()
            {
                color = color,
                name = "New",
                points = 0                      
            };
            players.Add(currentPlayer);
        }
        else
        {
            if (players.Count == 1)
                return;
            Debug.Log("delete");
            players.Remove(currentPlayer);
            currentPlayer = players[0];
        }
        PlayerChanged();
    }

    public void SwitchPlayer(bool positive)
    {
        int playerId;
        playerId = players.IndexOf(currentPlayer);
        if (positive)
        {
            currentPlayer = players[mod(playerId + 1,players.Count)];
        }

        else
        {
            currentPlayer = players[mod((playerId - 1),players.Count)];
        }
        PlayerChanged();
    }

    public void CurrentNicknameChanged()
    {
        Debug.Log("Edit");
        currentPlayer.name = inputField.text;
    }

    public void PlayerChanged()
    {
        Image image = gameObject.GetComponentInChildren<Image>();
        image.color = currentPlayer.color;
        inputField.SetTextWithoutNotify(currentPlayer.name);
    }

    int mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }
}
