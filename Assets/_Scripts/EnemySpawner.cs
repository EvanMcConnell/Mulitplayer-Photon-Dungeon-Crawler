using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (Transform t in transform)
            {
                PhotonNetwork.InstantiateRoomObject(enemyPrefab.name, t.position, Quaternion.identity);
                GameManager.Instance.currentRoom.enemyCount++;
            }
        }
    }
}
