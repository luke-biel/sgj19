using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

            var r = Random.rotation;
            this.transform.parent.localRotation = Quaternion.Euler(0, 0, r.eulerAngles.z);
            this.transform.localRotation = Quaternion.Euler(0, 0, r.eulerAngles.z * -1);
        }

        public void SetImage(Player player)
        {
            image.transform.parent.localScale = new Vector3(1f, 1f, 1f);
            image.transform.parent.DOPunchScale(Vector3.one * 0.3f, 5f, 5, 0.7f);
            pointsText.text = Math.Round(player.points, 2).ToString();
            pointsText.text = Math.Round(player.points, 2) + " pts.";
            if (player.image != null)
            {
                this.image.color = Color.white;
                this.image.sprite = player.image;
            }
            else
            {
                image.DOColor(player.color, 2f);
                this.image.color = player.color;
                this.image.sprite = null;
            }
        }
        public void SetPoints(Player player)
        {
            pointsText.text = Math.Round(player.points, 2).ToString();
            pointsText.text = Math.Round(player.points, 2).ToString();
        }

    }
}