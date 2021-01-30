using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;
public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public Room currentRoom;

    public PlayerScript player;

    //List of all rooms in scene
    public List<Room> RoomList;
    //Lisr index of current room
    public int RoomIndex;

    public List<Collectibles> collectibles;
    public PostProcessVolume postProcessVolume;

    int prologyIndex;

    void Start()
    {
        RoomIndex = 0;
        currentRoom = RoomList[RoomIndex];
        ChangeRoom(currentRoom);

        //Starting of the game
        prologyIndex = 0;
    }

    private void Update()
    {

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

        if(prologyIndex > 3){
            player.transform.position = room.RoomPlayerSpawn.transform.position;     
            player.agent.enabled = true;
        }
    }
    private void UpdateCameraPosition(Room room)
    {
        GameCamera.transform.position = room.RoomCameraPosition.transform.position;
        //GameCamera.transform.position = Vector3.Lerp(GameCamera.transform.position, room.RoomCameraPosition.transform.position, 20);
        //GameCamera.transform.rotation = room.RoomCameraPosition.transform.rotation;
    }

    public void Collect()
    {
        postProcessVolume.weight -= 0.1f;
    }
    
}
