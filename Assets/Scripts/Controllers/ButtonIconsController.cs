using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ButtonIconsController : MonoBehaviour
    {
        public Transform frontButton;
        public ButtonGridController grid;

        public void SetFront(Data.Button button)
        {
            Instantiate(Resources.Load<GameObject>(button.name), frontButton);
            Push(button);
        }

        private void Push(Data.Button button)
        {
            grid.Push(button);
        }
    }
}
