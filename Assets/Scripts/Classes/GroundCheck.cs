using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Poolingmanager poolingmanager;
    void groundCheck()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, .5f, .25f), new Vector3(0, -1, 1));

        // Ray ray = new Ray(transform.position + new Vector3(0, 1, 0), new Vector3(0, -1, 1));
        // Ray ray2 = new Ray(transform.position + new Vector3(0, 1, 0), new Vector3(0, -1, -1));
        RaycastHit hitinfo;
        Debug.DrawRay(transform.position+new Vector3(0, .5f, .25f), new Vector3(0, -1, 1) * 20, Color.red, 1f);
        // Debug.DrawRay(transform.position + new Vector3(0, 1, 0), new Vector3(0, -1, 1) * 20, Color.red, 2f);
        // Debug.DrawRay(transform.position + new Vector3(0, 1, 0), new Vector3(0, -1, -1) * 20, Color.red, 2f);
        if (Physics.Raycast(ray, out hitinfo, 5000))// || Physics.Raycast(ray2, out hitinfo, 5000))
        {
            if (hitinfo.collider.tag == "Ground")
            {
                PlayerMovement.gravity = 0;
            }
        }
        else if (!Physics.Raycast(ray, out hitinfo, 5000))
        {           
            Vector3 Pos = transform.position;
            Pos.y = -.25f;
            transform.position = Pos;
          
        }
        if (ExitBrdige.isExit)
        {
            Vector3 Pos = transform.position;
            Pos.y = .5f+poolingmanager.counter*.5f;
            transform.position = Pos;
        }
    }

    void CheckHighFromGround()
    {
        if (transform.position.y <= -2)
        {
            // TO DO: GameOver;
        }
    }
    void Update()
    {
        groundCheck();
        CheckHighFromGround();
    }
}
