using System.Collections;
using System.Collections.Generic;
using System.IO;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        public static GameplayController Instance;
        public ButtonIconsController iconsController;
        public PlayerIconsController playerIconsController;
        public CounterPanel counterPanel;
        public List<Mobile_GridButton> sequence;
        public AudioSource audioSource;
        public List<AudioClip> audioClips;
        public AudioClip failClip;
        Container container;
        public int currentSequenceIndex;
        public Button RestartButton;
        public Button MenuButton;
        public KeyPressedController keyPressedController;
        List<string> CurrentQueue;
 
        List<Player> players;

        public void Awake()
        {
            RestartButton.onClick.AddListener(RestartGame);
            MenuButton.onClick.AddListener(GoToMainMenu);
            CurrentQueue = new List<string>();
            currentSequenceIndex = 0;

#if UNITY_STANDALONE


            keyPressedController = gameObject.GetComponent<KeyPressedController>();
            keyPressedController.ButtonPressedEvent += ButtonPressed;
#endif
            counterPanel.UpdateText(currentSequenceIndex, sequence.Count);
            container = FindObjectOfType<Container>();

        }

        private void RestartGame()
        {
            foreach (Player player in players)
            {
                player.points = 0;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void GoToMainMenu()
        {
            foreach (Player player in players)
            {
                player.points = 0;
            }
            #if UNITY_STANDALONE
                SceneManager.LoadScene("Menu");
            #else
                SceneManager.LoadScene("Mobile_Menu");    
            #endif
        }

        private void Start()
        {

            if (!Instance)
            {
                Instance = this;
            }
            
            players = container.players;
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
                    audioSource.clip = failClip;
                    audioSource.Play();
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
                System.Random random = new System.Random();
                int audioIndex = random.Next(0, audioClips.Count - 1);
                audioSource.clip = audioClips[audioIndex];
                audioSource.Play();

                currentSequenceIndex++;
                playerIconsController.AddPoints(1);
                iconsController.Push(buttonChanged);
                Debug.Log($"{buttonChanged}");
                if(CurrentQueue.Count==currentSequenceIndex)
                {
                    ViewInfo("Add!");
                }
            }
            else
            {
                audioSource.clip = failClip;
                audioSource.Play();
                iconsController.Push(buttonChanged);
                playerIconsController.AddPoints(-1);
                NextPlayer();
                CurrentQueue = new List<string>();
            }
            counterPanel.UpdateText(currentSequenceIndex,CurrentQueue.Count);

            return;
        }

        public void ViewInfo(string text)
        {

        }
        public void ViewInfo(Sprite sprite)
        {

        }
    }
}