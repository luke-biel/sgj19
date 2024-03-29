﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Data
{
    [RequireComponent(typeof(Image))]
    public class MobilePlayerIcon : MonoBehaviour
    {
        public Image image;
        [FormerlySerializedAs("PointsText")] public Text pointsText;
        public Text playerNameText;
        
        private void Awake()
        {
            this.image = GetComponent<Image>();
        }

        public void SetImage(Player player)
        {
            image.transform.localScale = new Vector3(1f,1f,1f);
            image.transform.DOPunchScale(Vector3.one * 0.2f, 5f, 3, 0.5f);
            image.DOColor(player.color, 3f);
            pointsText.text = Math.Round(player.points, 2) + " pts.";
            this.image.color = player.color;
            playerNameText.text = player.name;
            playerNameText.color = ColorRandomizer.InverseColor(image.color);
            pointsText.color = ColorRandomizer.InverseColor(image.color);
        }
        
        public void SetPoints(Player player)
        {
            pointsText.text = Math.Round(player.points, 2) + " pts.";
        }
    }
}
