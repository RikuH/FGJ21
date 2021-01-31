using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public Room currentRoom;

    public PlayerScript player;
    public GameObject animationGirl;
    public GameObject BedroomLight;

    //List of all rooms in scene
    public List<Room> RoomList;
    //Lisr index of current room
    public int RoomIndex;

    public List<Collectibles> collectibles;
    public PostProcessVolume postProcessVolume;
    public bool allIsCollected = false;
    int collected = 0;

    public CanvasScript canvasScript;

    public Image endImage;

    public bool gettedOut = false;
    bool prologyIsOver = false;

    AudioSource audio;

    bool DoOnce = true;

    void Start()
    {
        RoomIndex = 0;
        currentRoom = RoomList[RoomIndex];
        ChangeRoom(currentRoom);

        StartCoroutine(PrologyTimer());

        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (canvasScript.isEnded)
        {
            if(DoOnce)
            {
                DoOnce = false;
            StartCoroutine(EndGame());
            }
        }
    }
    public void GoToNextRoom(int RoomIndex)
    {
        ChangeRoom(RoomList[RoomIndex]);
    }
    public void ChangeRoom(Room room)
    {
        player.agent.enabled = false;

        currentRoom = room;
        UpdateCameraPosition(room);

        //player.agent.enabled = true;

        if (gettedOut)
        {
            Debug.Log(player.transform.position + " " + room.RoomPlayerSpawn.transform.position);
            player.agent.enabled = false;
            player.transform.position = room.RoomPlayerSpawn.transform.position;
        }

        player.agent.enabled = true;
    }
    private void UpdateCameraPosition(Room room)
    {
        GameCamera.transform.position = room.RoomCameraPosition.transform.position;
        //GameCamera.transform.position = Vector3.Lerp(GameCamera.transform.position, room.RoomCameraPosition.transform.position, 20);
        //GameCamera.transform.rotation = room.RoomCameraPosition.transform.rotation;
    }

    public void Collect()
    {

        collected += 1;
        audio.Play();

        postProcessVolume.weight -= 0.1f;
        if(collected == collectibles.Count - 1)
        {
            allIsCollected = true;
        }

        StartCoroutine(canvasScript.writeText(currentRoom));
       
    }

    IEnumerator PrologyTimer()
    {
        yield return new WaitForSeconds(23);
        player.gameObject.SetActive(true);
        animationGirl.SetActive(false);
        BedroomLight.SetActive(true);
        prologyIsOver = true;
        player.agent.enabled = true;
    }

    public IEnumerator EndGame()
    {
        endImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(32);
        SceneManager.LoadScene("MainMenu");
    }

}
