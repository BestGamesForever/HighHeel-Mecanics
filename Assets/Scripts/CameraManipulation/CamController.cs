using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    Transform Player;
    Vector3 offset;
    private Vector3 Movevector;
    private float Transition = 0.0f;
    private float AnimationDuration = 1.5f;
    private Vector3 AnimationOffset = new Vector3(0, 5, 5);

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - Player.position;   
    }	
	
	void Update ()
    {
        Movevector = Player.position + offset;
        //Movevector.x = 0;
        Movevector.y = Mathf.Clamp(Movevector.y, 2.5f, 50);
        if (Transition > 1)
        {
            transform.position = Movevector;  
        }
        else
        {              
            transform.position = Vector3.Lerp(Movevector+AnimationOffset, Movevector, Transition);             
             Transition += Time.deltaTime * 2 / AnimationDuration;
            transform.LookAt (Player.position + Vector3.up);
        }          
	}
}
