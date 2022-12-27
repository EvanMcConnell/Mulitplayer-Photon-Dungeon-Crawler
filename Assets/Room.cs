using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    
    public Transform player1Spawn, player2Spawn;

    public GameObject enemySpawner;

    [HideInInspector]
    public int enemyCount = 0;

    [SerializeField] Door door;

    public void finishRoom()
    {
        door.Open();
    }
}
