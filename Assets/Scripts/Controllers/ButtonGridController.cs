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

        public GameObject SetImage(GameObject prefab, string name)
        {
            Debug.Log(name);
            if (name.ToLower().Contains("dpad"))
            {
                Debug.Log("PRZESZLO");
                prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/" + name);
                prefab.GetComponentInChildren<Text>().text = string.Empty;
            }
            else if(name.Contains("JoystickButton"))
            {
                prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/" + name);
                switch (name[name.Length-1])
                {
                    case '0': prefab.GetComponentInChildren<Text>().text = "A"; break;
                    case '1': prefab.GetComponentInChildren<Text>().text = "B"; break;
                    case '2': prefab.GetComponentInChildren<Text>().text = "X"; break;
                    case '3': prefab.GetComponentInChildren<Text>().text = "Y"; break;
                    case '4': prefab.GetComponentInChildren<Text>().text = "LB"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/bumper"); ; break;
                    case '5': prefab.GetComponentInChildren<Text>().text = "RB"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/bumper"); ; break;
                    case '6': prefab.GetComponentInChildren<Text>().text = "SELECT"; break;
                    case '7': prefab.GetComponentInChildren<Text>().text = "START"; break;
                    case '8': prefab.GetComponentInChildren<Text>().text = "Left Pressed"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/ButtonPressed"); break;
                    case '9': prefab.GetComponentInChildren<Text>().text = "Right Pressed"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/ButtonPressed");  break;
                }
            }
            else if (name.Contains("Analog"))
            {
                Debug.Log(name.Substring(name.LastIndexOf("A")));
                prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/" + name.Substring(name.LastIndexOf("A")));
                if (name.Contains("left"))
                    prefab.GetComponentInChildren<Text>().text = "Left Analog";
                else
                    prefab.GetComponentInChildren<Text>().text = "Right Analog";
            }
            else
            {
                switch(name)
                {
                    case "Mouse2": prefab.GetComponentInChildren<Text>().text = "SCROLL"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/MouseControllerScroll"); break;
                    case "Mouse1": prefab.GetComponentInChildren<Text>().text = "RMB"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/MouseControllerRight");  break;
                    case "Mouse0": prefab.GetComponentInChildren<Text>().text = "LMB"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/MouseControllerLeft");  break;
                    case "LeftTrigger": prefab.GetComponentInChildren<Text>().text = "LT"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/LeftTrigger"); break;
                    case "RightTrigger": prefab.GetComponentInChildren<Text>().text = "RT"; prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/RightTrigger"); break;
                    default:                
                        prefab.GetComponentInChildren<Text>().text = name;
                        prefab.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/default");
                        break;
                }

            }


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