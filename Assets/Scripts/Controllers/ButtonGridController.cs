using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class ButtonGridController : MonoBehaviour
    {
        private HorizontalLayoutGroup grid;
        private Queue<GameObject> buttons;
        private int length;

        private void Awake()
        {
            this.grid = GetComponent<HorizontalLayoutGroup>();
            this.buttons = new Queue<GameObject>(12);
        }

        public void Push(Data.Button button)
        {
            var prefab = Resources.Load<GameObject>(button.name);
            var go = Instantiate(prefab, transform);

            if (this.buttons.Count >= 18)
            {
                var d = this.buttons.Dequeue();
                Destroy(d);
            }

            this.buttons.Enqueue(go);
        }
    }
}