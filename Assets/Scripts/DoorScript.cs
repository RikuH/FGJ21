using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameManager gameManager;
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
        Debug.Log(other);
        if(other.tag == "Player")
        {
            if (gameObject.name == "DoorFromBedroom")
                gameManager.GoToNextRoom(1);
            else if (gameObject.name == "DoorToKitchen")
                gameManager.GoToNextRoom(2);
            else if (gameObject.name == "DoorFromKitchen")
                gameManager.GoToNextRoom(1);
        }
    }
}
