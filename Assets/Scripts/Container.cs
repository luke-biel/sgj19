﻿using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<Player> players { get; set; }
    public int RoundNumber { get; set; }
    void Awake()
    {
        if (FindObjectsOfType<Container>().Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        RoundNumber = 3;
        players = new List<Player>()
        {
            new Player{name="New", color = Color.red},
            new Player{name="New2", color = Color.green}
        };
    }

}
