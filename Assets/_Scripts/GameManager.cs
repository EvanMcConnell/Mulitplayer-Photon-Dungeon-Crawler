using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{

    public static GameManager Instance;

    PhotonView PV;

    [SerializeField]
    Vector3 player1Spawn, player2Spawn;

    GameObject localPlayer;

    private int roomNumber = 0;

    private void Awake()
    {
        Instance = this;

        PV = GetComponent<PhotonView>();

        if (GameObject.Find("Player 1"))
        {
            localPlayer = PhotonNetwork.Instantiate("Player 2", player2Spawn, Quaternion.identity);
        }
        else
        {
            localPlayer = PhotonNetwork.Instantiate("Player 1", player1Spawn, Quaternion.identity);
        }

        localPlayer.AddComponent<PlayerMovement>();
    }


    private void Update()
    {
    }

}
