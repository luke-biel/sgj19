using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        public ButtonIconsController iconsController;
        public PlayerIconsController playerIconsController;
        KeyPressedController keyPressedController;
        List<string> CurrentRoundQueue;
        List<string> ActionQueue;
        List<Player> players;
        Player currentPlayer;

        public void Awake()
        {
            CurrentRoundQueue = new List<string>();
            ActionQueue = new List<string>();
            keyPressedController = gameObject.GetComponent<KeyPressedController>();
            keyPressedController.ButtonPressedEvent += ButtonPressed;
        }

        private IEnumerator Start()
        {
            players = new List<Player>()
            {  new Player { color = Color.cyan },
                new Player { color = Color.red }};
            this.playerIconsController.SetPlayers(players.ToArray());

            while (true)
            {
                yield return new WaitForSeconds(4f);

                this.playerIconsController.Next();
                this.iconsController.SetFront(new Button { name = "x" });
            }
        }

        public void ButtonPressed(string buttonChanged)
        {
            if(CurrentRoundQueue.Count == ActionQueue.Count)
            {
                ActionQueue.Add(buttonChanged);
                CurrentRoundQueue.Clear();
                Debug.Log($"dodano do kolejki {buttonChanged}, zmiana gracza");
                return;
            }
            if(ActionQueue[CurrentRoundQueue.Count]==buttonChanged)
            {
                CurrentRoundQueue.Add(buttonChanged);
                Debug.Log($"{buttonChanged}");
                return;
            }
            else
            {
                Debug.Log("Gracz przegral");
                Debug.Log("zmiana gracza");
                ActionQueue.Clear();
                CurrentRoundQueue.Clear();
            }
        }
    }
}