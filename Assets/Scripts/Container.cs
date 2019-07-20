using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<Player> players { get; set; }
    void Awake()
    {
        if (FindObjectsOfType<Container>().Length > 1)
            Destroy(this);
        DontDestroyOnLoad(gameObject);

        players = new List<Player>()
        {
            new Player{name="New", color = Color.red},
            new Player{name="New2", color = Color.green}
        };
    }

}
