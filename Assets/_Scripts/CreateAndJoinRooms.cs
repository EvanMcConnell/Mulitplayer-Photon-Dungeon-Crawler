using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMPro.TMP_InputField createInput;
    public TMPro.TMP_InputField joinInput;
    public TMPro.TMP_Text errorText;

    public void CreateRoom()
    {
        errorText.text = "";

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        errorText.text = "";
         
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)=> errorText.text = message;

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
        print(PhotonNetwork.PlayerListOthers.Length);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) => errorText.text = message;
}
