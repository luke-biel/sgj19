using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    List<Player> players;
    Player currentPlayer;
    InputField inputField;
    Container container;
    public GameObject webCamPrefab;
    public Image image;
    void Start()
    {
        container = FindObjectOfType<Container>().GetComponent<Container>();
        players = new List<Player>();
        inputField = gameObject.GetComponentInChildren<InputField>();
        currentPlayer = new Player()
        {
            color = new Color32(92, 10, 255, 255),
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
        Image image = this.image;

        if (currentPlayer.image != null)
        {
            image.sprite = currentPlayer.image;
            image.color = Color.white;
        }
        else
        {
            image.color = currentPlayer.color;
            image.sprite = null;
        }

        inputField.SetTextWithoutNotify(currentPlayer.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        container.players = players;
#if UNITY_STANDALONE
        SceneManager.LoadScene("Game");
#else
        SceneManager.LoadScene("Mobile_Main");
#endif
    }

    public void RunCam()
    {
        var o = (GameObject)Instantiate(this.webCamPrefab, transform);
        var c = o.GetComponent<WebCamController>();
        c.OnTextureShoot += texture =>
        {
            var r = new Rect(0, 0, texture.width, texture.height);

            var t = Sprite.Create(texture, r, Vector2.zero);
            currentPlayer.image = t;
            Destroy(o);
            PlayerChanged();
        };
    }

    int mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }
}
