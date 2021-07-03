using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private const float Lane_Distance = 1f;
    private const float Turn_speed = 0.5f;

    public static CharacterController controller;

    public float PlayerSpeed;   
    
    public static float gravity = 0; 

    private float AnimationDuration = 2.5f; 
    private float Starttime;
    Vector3 direction;
    Vector3 MoveVector;

    [SerializeField] float deltax;
    void Start()
    {
        controller = GetComponent<CharacterController>();      
        Starttime = Time.time;       
    }

    void Update()
    {
      //  if (isDead)
      //      return;
        if (Time.time - Starttime < AnimationDuration)
        {
            controller.Move(Vector3.forward * PlayerSpeed * Time.deltaTime);
            return;
        }

        float _horizontal = Input.GetAxis("Horizontal");
        
        if (_horizontal<0)//change
        {
            direction = new Vector3(transform.position.x - deltax, transform.position.y, transform.position.z);
            direction.x = Mathf.Clamp(direction.x, -1.75f, 1.75f);          
        }
        if (_horizontal>0)//change
        {
            direction = new Vector3(transform.position.x + deltax, transform.position.y, transform.position.z);
            direction.x = Mathf.Clamp(direction.x, -1.75f, 1.75f);           
        }

        MoveVector = Vector3.zero;
        MoveVector.x = (direction - transform.position).x * PlayerSpeed * 1.5f;
        MoveVector.y -= gravity*Time.deltaTime;
        MoveVector.z = PlayerSpeed;
       // anim.SetFloat("MoveSpeed", PlayerSpeed);
        controller.Move(MoveVector * Time.deltaTime);
       
        // for face turn
        Vector3 face = controller.velocity*2;
        face.y = 0;
        transform.forward = (Vector3.Lerp(transform.forward, face, Turn_speed));

    }   //finish update 

}
