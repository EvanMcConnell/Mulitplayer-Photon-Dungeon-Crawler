using Photon.Pun;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviourPun
{

    public static GameManager Instance;

    [SerializeField]
    private Room[] Rooms;

    private int roomNumber = 0;
    public Room currentRoom => Rooms[roomNumber];

    [HideInInspector]
    public PhotonView _PhotonView;

    [SerializeField]
    Camera cam;

    GameObject localPlayer;


    private void Awake()
    {
        Instance = this;

        _PhotonView = GetComponent<PhotonView>();

        if (GameObject.Find("Player 1"))
        {
            localPlayer = PhotonNetwork.Instantiate("Player 2", currentRoom.player2Spawn.position, Quaternion.identity);
        }
        else
        {
            localPlayer = PhotonNetwork.Instantiate("Player 1", currentRoom.player1Spawn.position, Quaternion.identity);
        }

        localPlayer.AddComponent<PlayerMovement>();
    }

    public void nextRoom() => _PhotonView.RPC("RPC_nextRoom", RpcTarget.AllBuffered);

    [PunRPC]
    void RPC_nextRoom()
    {
        roomNumber++;

        GameObject P1 = GameObject.Find("Player 1").transform.GetChild(0).gameObject;
        P1.GetComponent<CharacterController>().enabled = false;
        P1.transform.position = currentRoom.player1Spawn.position;
        P1.GetComponent<CharacterController>().enabled = true;
        //GameObject.Find("Player 2").transform.position = Rooms[roomNumber].player2Spawn;

        cam.transform.position += new Vector3(0, 0, 135);

        if(PhotonNetwork.IsMasterClient) StartCoroutine(gracePeriod());
    }

    IEnumerator gracePeriod()
    {
        yield return new WaitForSecondsRealtime(1f);
        currentRoom.enemySpawner.SetActive(true);
    }
}
