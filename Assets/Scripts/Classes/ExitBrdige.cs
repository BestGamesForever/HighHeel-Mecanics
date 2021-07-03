using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBrdige : MonoBehaviour
{
    [SerializeField] List<GameObject> Lshoes;
    [SerializeField] List<GameObject> Rshoes;
    [SerializeField] Poolingmanager _poolingManager;
    [SerializeField] Animator anim;
    [SerializeField] Transform _player;
    public GameObject[] item;
    public static bool isExit;
    public static bool isBridge;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Heel") || other.gameObject.tag == "Player")
        {
          
            isExit = true;
            anim.SetBool("Spread", false);
            for (int i = 3; i < 3+_poolingManager.counter; i++)
            {
                GameObject g = GameObject.Find("Woman Player").transform.GetChild(i).gameObject;
                g.SetActive(true);
            }
           
            // item = GameObject.FindGameObjectsWithTag("Heel");
            // foreach (GameObject items in item)
            // {
            //     items.SetActive(true);
            // }
            // Debug.Log("Hello");
        }

        for (int i = 0; i < _poolingManager.counter; i++)
        {
            Lshoes[i].SetActive(false);
            Rshoes[i].SetActive(false);
        }
        isBridge = false;
    }
}
