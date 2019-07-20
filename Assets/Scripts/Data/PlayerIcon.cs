using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Data
{
    [RequireComponent(typeof(Image))]
    public class PlayerIcon : MonoBehaviour
    {
        public Image image;
        [FormerlySerializedAs("PointsText")] public Text pointsText;
        
        private void Awake()
        {
            this.image = GetComponent<Image>();
            pointsText = GetComponentInChildren<Text>();
        }

        public void SetImage(Player player)
        {
            image.transform.DOPunchScale(Vector3.one * 0.3f, 5f, 5, 0.7f);
            image.DOColor(player.color, 5f);
            pointsText.text = Math.Round(player.Points, 2).ToString();
            this.image.color = player.color;
        }
        public void SetPoints(Player player)
        {
            pointsText.text = Math.Round(player.Points, 2).ToString();
        }
    }
}