using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    [RequireComponent(typeof(Image))]
    public class Icon : MonoBehaviour
    {
        public Image image;

        private void Awake()
        {
            this.image = GetComponent<Image>();
        }

        public void SetImage(Player player)
        {
            image.transform.DOPunchScale(Vector3.one * 0.3f,5f ,5,0.7f);
            image.DOColor(player.color, 5f);
            //this.image.color = player.color;
        }
    }
}