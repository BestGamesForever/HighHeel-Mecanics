using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    //Variables
    private float _shakeduration;
    private float _shakePower;

    private void Update()
    {
        Vector2 ShakeMovement = Random.insideUnitCircle * _shakePower;
        transform.position = new Vector3(transform.position.x + ShakeMovement.x, transform.position.y + ShakeMovement.y, transform.position.z);
        _shakeduration -= Time.deltaTime;
    }
    //Function with the constructers to decide variables;
    //work it whereever we want to with the values;
    public void MakeTheShake(float timer,float power)
    {
        _shakeduration = timer;
        _shakePower = power;
    }
}
