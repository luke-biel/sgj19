using System.Collections;
using System.Linq;
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
            this.icons = this.transform.GetComponentsInChildren<Icon>().Reverse().ToArray();

            // TODO: remove me
            SetPlayers(new []
            {
                new Player { color = Color.red },
                new Player { color = Color.blue },
                new Player { color = Color.green },
                new Player { color = Color.black },
            });
        }

        // TODO: remove me
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