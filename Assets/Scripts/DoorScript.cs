using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = new GameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (gameObject.name == "DoorFromBedroom")
            {
                gameManager.gettedOut = true;
                gameManager.GoToNextRoom(1);
            }
            else if (gameObject.name == "DoorToBedroom")
                gameManager.GoToNextRoom(0);

            else if (gameObject.name == "DoorFromKitchen")
                gameManager.GoToNextRoom(1);
            else if (gameObject.name == "DoorToKitchen")
                gameManager.GoToNextRoom(2);

            else if (gameObject.name == "DoorToSecondCorridor")
                gameManager.GoToNextRoom(3);
            else if (gameObject.name == "DoorToFirstCorridor")
                gameManager.GoToNextRoom(1);
            else if (gameObject.name == "DoorToThirdCorridor")
                gameManager.GoToNextRoom(5);

            else if (gameObject.name == "DoorToLibrary")
                gameManager.GoToNextRoom(4);
            else if (gameObject.name == "DoorFromLibrary")
                gameManager.GoToNextRoom(3);

            else if (gameObject.name == "DoorToLivingroom")
                gameManager.GoToNextRoom(6);
            else if (gameObject.name == "DoorFromLivingroom")
                gameManager.GoToNextRoom(5);

            else if (gameObject.name == "DoorToWorkroom")
                gameManager.GoToNextRoom(7);
            else if (gameObject.name == "DoorFromWorkroom")
                gameManager.GoToNextRoom(5);

            else if (gameObject.name == "LaddersToAttic")
            {
                if (player.goLadder)
                {
                    if(gameManager.allIsCollected)
                        gameManager.GoToNextRoom(8);
                }
            }

            else if (gameObject.name == "StairsToBasement")
            {
                if (player.goStairs)
                {
                    gameManager.GoToNextRoom(9);
                }
            }

            else if (gameObject.name == "DoorFromBasement")
                gameManager.GoToNextRoom(2);
        }
    }
}
