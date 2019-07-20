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

        public Data.Button GetImage(string name)
        {
            Data.Button button = new Data.Button();

            if (name.ToLower().Contains("dpad"))
            {
                button.sprite = Resources.Load<Sprite>("Graphics/" + name);
                button.name = " ";
            }
            else if (name.Contains("JoystickButton"))
            {
                button.sprite = Resources.Load<Sprite>("Graphics/" + name);
                switch (name[name.Length - 1])
                {
                    case '0': button.name = "A"; break;
                    case '1': button.name = "B"; break;
                    case '2': button.name = "X"; break;
                    case '3': button.name = "Y"; break;
                    case '4': button.name = "LB"; button.sprite = Resources.Load<Sprite>("Graphics/bumper"); ; break;
                    case '5': button.name = "RB"; button.sprite = Resources.Load<Sprite>("Graphics/bumper"); ; break;
                    case '6': button.name = "SELECT"; break;
                    case '7': button.name = "START"; break;
                    case '8': button.name = "Left Pressed"; button.sprite = Resources.Load<Sprite>("Graphics/ButtonPressed"); break;
                    case '9': button.name = "Right Pressed"; button.sprite = Resources.Load<Sprite>("Graphics/ButtonPressed"); break;
                }
            }
            else if (name.Contains("Analog"))
            {
                button.sprite = Resources.Load<Sprite>("Graphics/" + name.Substring(name.LastIndexOf("A")));
                if (name.Contains("left"))
                    button.name = "Left Analog";
                else
                    button.name = "Right Analog";
            }
            else
            {
                switch (name)
                {
                    case "Mouse2": button.name = " "; button.sprite = Resources.Load<Sprite>("Graphics/MouseControllerScroll"); break;
                    case "Mouse1": button.name = " "; button.sprite = Resources.Load<Sprite>("Graphics/MouseControllerRight"); break;
                    case "Mouse0": button.name = " "; button.sprite = Resources.Load<Sprite>("Graphics/MouseControllerLeft"); break;
                    case "LeftTrigger": button.name = "LT"; button.sprite = Resources.Load<Sprite>("Graphics/LeftTrigger"); break;
                    case "RightTrigger": button.name = "RT"; button.sprite = Resources.Load<Sprite>("Graphics/RightTrigger"); break;
                    default:
                        button.name = name;
                        button.sprite = Resources.Load<Sprite>("Graphics/default");
                        break;
                }
            }
            return button;
        }


        public GameObject SetImage(GameObject prefab, string name)
        {
            Data.Button button = GetImage(name);

            prefab.GetComponentInChildren<Text>().text = button.name;
            prefab.GetComponent<Image>().sprite = button.sprite;
            return prefab;
        }

        public void Push(string button)
        {
            var prefab = SetImage(Resources.Load<GameObject>("x"), button);
            var go = Instantiate(prefab, transform);
            if (buttons.Count >= 18)
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
            Debug.Log("clearuje");
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}