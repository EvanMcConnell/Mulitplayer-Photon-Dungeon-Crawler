using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameSetter : MonoBehaviour
{
    [SerializeField]
    string newName;

    private void Awake()
    {
        name = newName;
    }
}
