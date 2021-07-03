using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerForShake : MonoBehaviour
{
    private ShakeCamera _shakeCamera;
    void Start()
    {
        _shakeCamera = GameObject.FindGameObjectWithTag("Camera").GetComponent<ShakeCamera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _shakeCamera.MakeTheShake(.1f, .5f);
        Handheld.Vibrate();
    }

}
