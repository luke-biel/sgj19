using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ButtonIconsController : MonoBehaviour
    {
        public Image frontButton;
        public ButtonGridController grid;

        public void SetFront(Button button)
        {
            frontButton.sprite = Resources.Load<Sprite>(button.name);
        }

        public void Push(Button button)
        {
            grid.Push(button);
        }
    }
}
