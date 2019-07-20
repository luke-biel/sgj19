using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        public static GameplayController Instance;
        public ButtonIconsController iconsController;
        public PlayerIconsController playerIconsController;
        public List<Mobile_GridButton> sequence;
        public int currentSequenceIndex;

        public KeyPressedController keyPressedController;
        List<string> CurrentQueue;

        List<Player> players;

        public void Awake()
        {
            CurrentQueue = new List<string>();
            currentSequenceIndex = 0;
            
            keyPressedController = gameObject.GetComponent<KeyPressedController>();
            keyPressedController.ButtonPressedEvent += ButtonPressed;
        }

        private void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }
            players = new List<Player>()
            {  new Player { color = Color.cyan },
                new Player { color = Color.red },
            new Player{color = Color.magenta } };
            this.playerIconsController.SetPlayers(players.ToArray());
        }

        public void NextPlayer()
        {
            currentSequenceIndex = 0;
            iconsController.grid.Clear();
            playerIconsController.Next();
        }


        public bool CheckWithSequence(Mobile_GridButton mobileGridButton)
        {
            int playerIndex = playerIconsController.ActivePlayerIndex;
            iconsController.SetFront(mobileGridButton);
            if (currentSequenceIndex >= sequence.Count)
            {
                int trend = sequence.FindAll(button => button == mobileGridButton).Count;
                Debug.Log("new element " + trend + "'th time");
                if (trend == 0)
                {
                    Debug.Log("added player nr."+ playerIndex +" 1 point");
                    playerIconsController.AddPoints(1);
                }
                else
                {
                    Debug.Log("added nr." + playerIndex + " " + (1 - trend / (float)sequence.Count) + " points");
                    playerIconsController.AddPoints( 1 - trend / (float)sequence.Count);
                }
                sequence.Add(mobileGridButton);
                NextPlayer();
                return true;
            }
            else
            {
                if (sequence[currentSequenceIndex] == mobileGridButton)
                {
                    Debug.Log("old element good choice");
                    Debug.Log("added nr."+ playerIndex +" 1 point");
                    playerIconsController.AddPoints(1);
                    currentSequenceIndex++;
                    iconsController.Push(mobileGridButton);
                    return true;
                }
                else
                {
//                  Debug.Log("old element wrong choice");
//                  Debug.Log("removed 1 point");
                    Handheld.Vibrate();
//                  playerIconsController.players[playerIndex].Points--;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return false;
                }
            }
        }



        public void ButtonPressed(string buttonChanged)
        {
            float pointsToAdd;
            if(CurrentQueue.Count == currentSequenceIndex)
            {
                int trend = CurrentQueue.FindAll(button => button == buttonChanged).Count;
                pointsToAdd = 1 - trend/((float)CurrentQueue.Count + 1);
                CurrentQueue.Add(buttonChanged);
                Debug.Log($"dodano do kolejki {buttonChanged}, zmiana gracza");
                playerIconsController.AddPoints(pointsToAdd);
                NextPlayer();

            }
            else if(CurrentQueue[currentSequenceIndex]==buttonChanged)
            {
                currentSequenceIndex++;
                playerIconsController.AddPoints(1);
                iconsController.Push(buttonChanged);
                Debug.Log($"{buttonChanged}");
            }
            else
            {
                Debug.Log("Gracz przegral");
                Debug.Log("zmiana gracza");
                iconsController.Push(buttonChanged);
                playerIconsController.AddPoints(-1);
                NextPlayer();
                CurrentQueue = new List<string>();
            }
            return;
        }
    }
}