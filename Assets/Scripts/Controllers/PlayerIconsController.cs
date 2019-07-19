using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Controllers
{
    public class PlayerIconsController : MonoBehaviour
    {
        private Player[] players;
        private int activePlayer;
        private Icon[] icons;

        private void Awake()
        {
            var children = new List<Icon>();

            foreach (var item in this.transform.GetComponentsInChildren<Icon>())
            {
                children.Add(item);
            }

            children.Reverse();

            this.icons = children.ToArray();

            SetPlayers(new []
            {
                new Player { color = Color.red },
                new Player { color = Color.blue },
                new Player { color = Color.green },
                new Player { color = Color.black },
            });
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);

                Next();
            }
        }

        public void SetPlayers(Player[] players)
        {
            this.players = players;
            this.activePlayer = 0;
            UpdatePlayers();
        }

        public void Next()
        {
            this.activePlayer = (this.activePlayer + 1) % players.Length;
            UpdatePlayers();
        }

        private void UpdatePlayers()
        {
            for (var i = 0; i < icons.Length; i++)
            {
                icons[i].SetImage(players[(activePlayer + i) % players.Length]);
            }
        }
    }
}