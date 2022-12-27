using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : MonoBehaviourPun
{
    [SerializeField]
    Sprite openSprite;

    [SerializeField]
    private AudioClip unlockSound;

    public void Open()
    {
        GetComponent<PhotonView>().RPC("RPC_Open", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void RPC_Open()
    {
        print("rpc door opened");
        GetComponent<BoxCollider>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().sprite = openSprite;
        GetComponent<AudioSource>().PlayOneShot(unlockSound);
    }

}
