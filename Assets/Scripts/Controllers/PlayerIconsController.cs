using System;
using System.Collections;
using System.Linq;
using Data;
using UnityEngine;

namespace Controllers
{
    public class PlayerIconsController : MonoBehaviour
    {
        private Player[] players;
        public int ActivePlayerIndex { get; private set; }
        private PlayerIcon[] _playerIcons;

        private void Awake()
        {
            this._playerIcons = this.transform.GetComponentsInChildren<PlayerIcon>().Reverse().ToArray();
        }

        public void SetPlayers(Player[] players)
        {
            this.players = players;
            this.ActivePlayerIndex = 0;
            UpdatePlayers();
        }

        public void Next()
        {
            this.ActivePlayerIndex = (this.ActivePlayerIndex + 1) % players.Length;
            UpdatePlayers();
        }

        private void UpdatePlayers()
        {
            for (var i = 0; i < _playerIcons.Length; i++)
            {
                _playerIcons[i].SetImage(players[(ActivePlayerIndex + i + 1) % players.Length]);
            }
        }

        public void AddPoints(float i)
        {
            players[ActivePlayerIndex].Points += i;
            UpdatePlayers();
        }
    }
}