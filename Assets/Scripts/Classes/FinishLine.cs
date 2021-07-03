using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    float time;
   [SerializeField] Transform _player;
    [SerializeField] Camera _mainCam;
    [SerializeField] Vector3 offset;
    [SerializeField] ParticleSystem _confetti;
    bool isTrigger;

    
    void LateUpdate()
    {
        if (isTrigger)
        {
            offset = Quaternion.AngleAxis(.75f, Vector3.up) * offset;
            _mainCam.transform.position = _player.position + offset;
            _mainCam.transform.LookAt(_player.position);
        }
    }       
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("Heel"))
        {
            _player.GetComponent<CharacterController>().enabled = false;
            _player.GetComponent<Animator>().enabled = false;
            isTrigger = true;
            _confetti.Play();
        }
    }
  
}
