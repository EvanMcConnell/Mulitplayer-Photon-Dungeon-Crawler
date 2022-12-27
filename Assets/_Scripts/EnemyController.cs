using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform target;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.Find("Player 1").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        print(GameManager.Instance.currentRoom.enemyCount);
        if(--GameManager.Instance.currentRoom.enemyCount < 1)
        {
            GameManager.Instance.currentRoom.finishRoom();
        }
        print(GameManager.Instance.currentRoom.enemyCount);
    }
}
