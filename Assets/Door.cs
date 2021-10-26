using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite openSprite;

    [SerializeField] bool open = false;

    private void Update()
    {
        if (open) Open();
    }


    public void Open()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        GetComponentInChildren<SpriteRenderer>().sprite = openSprite;
    }

}
