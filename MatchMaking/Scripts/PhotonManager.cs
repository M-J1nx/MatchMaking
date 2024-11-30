using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    // Access to Photno Engine
    void Start()
    {
        JoinPhotonEngine();
    }

    void Update()
    {

    }

    // Access to Photon Engine
    private void JoinPhotonEngine()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // Scene Syncronize
        Debug.Log("Attempting to connect to Photon");
        PhotonNetwork.ConnectUsingSettings(); // Connecting to master channel 
    }

    // Enter to lobby after successfully access to master channel 
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server.");
        JoinLobby();
    }

    // Join lobby
    private void JoinLobby()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Debug.Log("Joining Lobby");
            PhotonNetwork.JoinLobby();
        }
    }

    // Create or join room after successfully access to lobby 
    public override void OnJoinedLobby()
    {
        Debug.Log("Successfully joined the lobby.");
        JoinOrCreateRoom();
    }

    // Join or create room 
    private void JoinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 2
        };

        PhotonNetwork.JoinOrCreateRoom("testRoom", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room successfully!");
        GameObject player = PhotonNetwork.Instantiate("testplayer", Vector3.zero, Quaternion.identity);
        PhotonView photonView = player.GetComponent<PhotonView>();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Failed to join room: {message}");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Failed to create room: {message}");
    }
}
