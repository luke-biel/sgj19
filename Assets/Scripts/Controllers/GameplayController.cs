using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        public static GameplayController Instance;
        public ButtonIconsController iconsController;
        public PlayerIconsController playerIconsController;
        public List<Mobile_GridButton> sequence;
        public int currentSequenceIndex;

        private void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }

            this.playerIconsController.SetPlayers(new[]
            {
                new Player {color = Color.cyan},
                new Player {color = Color.red},
            });
            
            
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
//                    Debug.Log("old element wrong choice");
//                    Debug.Log("removed 1 point");
                    Handheld.Vibrate();
//                    playerIconsController.players[playerIndex].Points--;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return false;
                }
            }
        }
    }
}