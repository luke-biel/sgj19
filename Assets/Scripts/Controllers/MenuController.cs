using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class MenuController : MonoBehaviour
{
    List<Player> players;
    Player currentPlayer;
    InputField inputField;
    Container container;

    public AudioClip clickClip;
    public AudioClip exitClip;
    public AudioClip startClip;
    public AudioSource audioSource;
    public Button MaskButton;
    public Text playerCount;
    public GameObject webCamPrefab;
    public Image image;
    void Start()
    {
        MaskButton.onClick.AddListener(ResetMaskColor);
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

    private void ResetMaskColor()
    {
        ColorRandomizer.ResetColor(image);
        currentPlayer.color = image.color;
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
        audioSource.clip = clickClip;
        audioSource.Play();
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
        audioSource.clip = clickClip;
        audioSource.Play();
        Image image = this.image;
        playerCount.text = "Players: " + players.Count;
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
        audioSource.clip = exitClip;
        StartCoroutine(ExitGameEnum());
    }

    public void StartGame()
    {
        container.players = players;
        audioSource.clip = startClip;
#if UNITY_STANDALONE
        StartCoroutine(StartGameEnum());
#else
        SceneManager.LoadScene("Mobile_Main");
#endif
    }
    
    public void StartGameMeme()
    {
        container.players = players;
        audioSource.clip = startClip;
        SceneManager.LoadScene("Mobile_Main_Meme");
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

    IEnumerator StartGameEnum()
    {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        SceneManager.LoadScene("Game");
    }

    IEnumerator ExitGameEnum()
    {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        Application.Quit();
    }

    int mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }
}
