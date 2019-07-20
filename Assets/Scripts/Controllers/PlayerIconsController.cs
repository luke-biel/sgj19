using System;
using System.Collections;
using System.Linq;
using Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class PlayerIconsController : MonoBehaviour
    {
        [SerializeField]private Player[] players;
        public int ActivePlayerIndex { get; private set; }
        private PlayerIcon[] _playerIcons;
        [SerializeField] private MobilePlayerIcon mobilePlayerIcon;
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
                _playerIcons[i].SetImage(players[(ActivePlayerIndex + i) % players.Length]);
            }
            
            #if !UNITY_STANDALONE
            mobilePlayerIcon.SetImage(players[ActivePlayerIndex]);
            #endif
        }
        private void UpdateText()
        {
            for (var i = 0; i < _playerIcons.Length; i++)
            {
                _playerIcons[i].SetPoints(players[(ActivePlayerIndex + i) % players.Length]);
            }
            
            #if !UNITY_STANDALONE
            mobilePlayerIcon.SetPoints(players[ActivePlayerIndex]);
            #endif
        }

        public void AddPoints(float i)
        {
            players[(ActivePlayerIndex) % players.Length].points += i;
            UpdateText();
        }
    }
}