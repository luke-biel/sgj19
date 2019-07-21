using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    [RequireComponent(typeof(Image))]
    public class LastButtonPressed : MonoBehaviour
    {
        private Image image;
        public Text child;

        private void Awake()
        {
            this.image = GetComponent<Image>();
        }

        public void Update()
        {
            var c = image.color;
            var x = Mathf.Lerp(c.a, 0, Time.deltaTime * 2f);

            this.image.color = new Color(c.r, c.g, c.b, x);

            var cc = child.color;
            this.child.color = new Color(cc.r, cc.g, cc.b, x);
        }

        public void SetImage(Sprite s)
        {
            this.image.sprite = s;
            this.image.color = Color.white;
            this.child.color = Color.black;
        }
    }
}
