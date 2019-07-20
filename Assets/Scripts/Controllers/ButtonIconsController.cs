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

        public void SetFront(Data.Button button)
        {
            Instantiate(Resources.Load<GameObject>(button.name), currentInputAnimator.transform);
            Push(button);
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

        public void Push(Data.Button button)
        {
            grid.Push(button);
        }
        
        public void Push(Mobile_GridButton gridButton)
        {
            grid.Push(gridButton);
        }
        
        private void ShowCurrentInput()
        {
            currentInputAnimator.SetTrigger("GotInput");
        }
    }
}
