using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
        public CounterPanel counterPanel;
        public List<Mobile_GridButton> sequence;
        public int currentSequenceIndex;

        public KeyPressedController keyPressedController;
        List<string> CurrentQueue;

        List<Player> players;

        public void Awake()
        {
            CurrentQueue = new List<string>();
            currentSequenceIndex = 0;

#if UNITY_STANDALONE
                 
            keyPressedController = gameObject.GetComponent<KeyPressedController>();
            keyPressedController.ButtonPressedEvent += ButtonPressed;       
#endif
        }

        private void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }
            players = new List<Player>()
            {  new Player {name = "Player 1", color = Color.cyan },
                new Player {name = "Player 2", color = Color.red },
            new Player{name = "Player 3",color = Color.magenta } };
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
                    Handheld.Vibrate();
                    playerIconsController.AddPoints(-1);
                    iconsController.Push(mobileGridButton);
                    sequence.Clear();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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