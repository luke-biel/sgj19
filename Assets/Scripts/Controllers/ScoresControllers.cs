using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoresControllers : MonoBehaviour
{
    // Start is called before the first frame update
    Container container;
    List<Player> players;
    public GameObject grid;
    public GameObject myPrefab;
    public AudioClip exitClip;
    public AudioClip startClip;
    public AudioSource audioSource;

    void Start()
    {
        container = FindObjectOfType<Container>().GetComponent<Container>();
        players = container.players;
        container.players = new List<Player>();
        players.Sort((p, q) => p.name.CompareTo(q.name));
        players.Reverse();

        foreach(Player player in players)
        {
            GameObject go = Instantiate(myPrefab,grid.transform);
            var texts = go.GetComponentsInChildren<Text>();
            go.GetComponentInChildren<Image>();
            if (player.image != null)
                go.GetComponentInChildren<Image>().sprite = player.image;
            else
                go.GetComponentInChildren<Image>().color = player.color;
            texts[0].text = player.name;
            texts[1].text = player.points.ToString();
        }

    }

    public void GoToMenu()
    {
        audioSource.clip = startClip;
        StartCoroutine(MenuEnum());
    }
    public void ExitGame()
    {
        audioSource.clip = exitClip;
        StartCoroutine(ExitGameEnum());
    }
    IEnumerator MenuEnum()
    {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator ExitGameEnum()
    {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        Application.Quit();
    }


}
