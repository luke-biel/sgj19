using System;
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
            this.image.color = player.color;
        }
    }
}