using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RPCSpriteHandler : MonoBehaviourPun
{
    private PhotonView PV;
    private SpriteRenderer sprite;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void flip(bool state)
    {
        PV.RPC("RPC_flip", RpcTarget.AllBuffered, state);
    }


    [PunRPC]
    void RPC_flip(bool state)
    {
        sprite.flipX = state;
    }
}
