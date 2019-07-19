using System.Collections;
using Data;
using UnityEngine;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        public ButtonIconsController iconsController;
        public PlayerIconsController playerIconsController;

        private IEnumerator Start()
        {
            this.playerIconsController.SetPlayers(new []
            {
                new Player { color = Color.cyan },
                new Player { color = Color.red },
            });

            while (true)
            {
                yield return new WaitForSeconds(4f);

                this.playerIconsController.Next();
                this.iconsController.SetFront(new Button { name = "x" });
            }
        }
    }
}