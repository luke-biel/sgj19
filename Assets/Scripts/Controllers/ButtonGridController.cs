using System;
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

        [SerializeField]
        private GameObject prefab;
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
        
        public void Push(Mobile_GridButton button)
        {
            var go = Instantiate(prefab, transform);
            HistoryInput historyInput = go.GetComponent<HistoryInput>();

            historyInput.SetHistoryInput(button);
            
            if (this.buttons.Count >= 4)
            {
                var d = this.buttons.Dequeue();
                Destroy(d);
            }

            this.buttons.Enqueue(go);
        }

        public void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}