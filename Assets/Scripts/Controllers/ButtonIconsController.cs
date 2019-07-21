using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Controllers
{
    public class ButtonIconsController : MonoBehaviour
    {
        public Image currentInputIcon;
        public Image currentInputBackground;
        public Text currentInputText;
        public Animator currentInputAnimator;
        public ButtonGridController grid;

        public void SetFront(GameObject o, string button)
        {
            var p = grid.SetImage(o, button);
            var component = p.GetComponent<Image>();

            var c = component.color;

            component.color = new Color(c.r, c.g, c.b, 1);
            component.GetComponentInChildren<Text>().color = Color.black;
        }

        public void SetFront(Mobile_GridButton gridButton)
        {
            currentInputBackground.color = gridButton.background.color;
            currentInputBackground.sprite = gridButton.background.sprite;
            currentInputIcon.color = gridButton.icon.color;
            currentInputIcon.sprite = gridButton.icon.sprite;
            currentInputText.text = gridButton.text.text;
            ShowCurrentInput();
        }

        public void Push(string button)
        {
            grid.Push(button);
        }


        public void Push(Mobile_GridButton gridButton)
        {
            grid.Push(gridButton);
        }

        public void ShowCurrentInput()
        {
            currentInputAnimator.SetTrigger("GotInput");
        }
    }
}
