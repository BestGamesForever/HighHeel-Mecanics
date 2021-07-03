using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBridge : MonoBehaviour
{
    [SerializeField] List<GameObject> Lshoes;
    [SerializeField] List<GameObject> Rshoes;
    [SerializeField] Poolingmanager _poolingManager;
    [SerializeField] Animator anim;
    [SerializeField] Transform _player;
    public GameObject[] item;
    public static bool isBridge;
    [SerializeField] CapsuleCollider[] _shoesColliders;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Heel") || other.gameObject.tag == "Player")
        {
            for (int i = 0; i < _shoesColliders.Length; i++)
            {
                _shoesColliders[i].height = 1 + _poolingManager.counter;
                _shoesColliders[i].center = new Vector3(0, -0.4f * _poolingManager.counter,0);
            }
            anim.SetBool("Spread", true);
            item = GameObject.FindGameObjectsWithTag("Heel");
            foreach (GameObject items in item)
            {
                items.SetActive(false);
            }
            for (int i = 0; i < _poolingManager.counter; i++)
            {
                Lshoes[i].SetActive(true);
                Rshoes[i].SetActive(true);
            }
            isBridge = true;
        }
       
    }   
}

