using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeManager : MonoBehaviour
{
    public Poolingmanager poolingmanager;
    [SerializeField] PlayerUPDown _playerUpDown;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("Heel"))
        {           
            _playerUpDown.CalculateUP();
            poolingmanager.getShooes();
            gameObject.SetActive(false);           
        }
    }
}
