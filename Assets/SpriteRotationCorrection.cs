using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotationCorrection : MonoBehaviour
{

    Vector3 defaultRotation;

    private void Awake() => defaultRotation = transform.rotation.eulerAngles;
    void Update() =>  transform.eulerAngles = defaultRotation;
}
