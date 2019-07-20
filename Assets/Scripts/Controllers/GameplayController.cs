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
            {  new Player { color = Color.cyan, name= "new" },
                new Player { color = Color.red, name= "new" },
            new Player{color = Color.magenta, name= "new" } };
            this.playerIconsController.SetPlayers(players.ToArray());
        }

        public void NextPlayer()
        {
            currentSequenceIndex = 0;
            iconsController.grid.Clear();
            playerIconsController.Next();
        }


        public void CheckWithSequence(Mobile_GridButton mobileGridButton)
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
                if (mobileGridButton.audioSource.clip != null)
                {
                    mobileGridButton.audioSource.Play();
                }
                sequence.Add(mobileGridButton);
                NextPlayer();
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
                    if (mobileGridButton.audioSource.clip != null)
                    {
                        mobileGridButton.audioSource.Play();
                    }
                }
                else
                {
//                  Debug.Log("old element wrong choice");
                    Handheld.Vibrate();
                    playerIconsController.AddPoints(-1);
                    iconsController.Push(mobileGridButton);
                    sequence.Clear();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            counterPanel.UpdateText(currentSequenceIndex,sequence.Count);

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
            counterPanel.UpdateText(currentSequenceIndex,CurrentQueue.Count);

            return;
        }
    }
}