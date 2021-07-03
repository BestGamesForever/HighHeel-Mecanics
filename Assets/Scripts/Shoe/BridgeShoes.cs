using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeShoes : MonoBehaviour
{
    [SerializeField] GroundCheck _groundCheck;
    bool isBridge;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BridgeShoes"))
        {
            isBridge = true;
            PlayerMovement.gravity = 0;
            Debug.Log("BridgeEnter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isBridge)
        {
            if (other.gameObject.CompareTag("BridgeShoes"))
            {
                Debug.Log("BridgeDown");
                PlayerMovement.gravity = 50;
                // yield return new WaitForSeconds(1f);
                _groundCheck.enabled = false;
                //TO DO Finish Game
            }
        }

    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (isBridge)
    //    {
    //        if (other.gameObject.CompareTag("BridgeShoes"))
    //        {
    //            PlayerMovement.gravity = 0;
    //            Debug.Log("Bridge");
    //        }
    //        else
    //        {
    //            Debug.Log("BridgeDown");
    //            PlayerMovement.gravity = 50;
    //            // yield return new WaitForSeconds(1f);
    //            _groundCheck.enabled = false;
    //            //TO DO Finish Game
    //        }
    //    }
    //
    //}
    //IEnumerator downtheBridge()
    //{
    //    
    //}
}
