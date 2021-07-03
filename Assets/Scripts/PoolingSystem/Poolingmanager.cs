
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolingmanager : MonoBehaviour
{

    [SerializeField] Transform Player;
    [SerializeField] Transform LeftLeg;
    [SerializeField] Transform RightLeg;
    [SerializeField] GameObject ObjToPooling;
    public Queue<GameObject> poolingObjs = new Queue<GameObject>();
    public List<GameObject> PoolingToListToremove = new List<GameObject>();
    [SerializeField] int startSize;
    public int counter;
    private void Start()
    {
        Vector3 _startpos = Player.position;
        Vector3 currentPos = new Vector3(0, -.5f, 0) + _startpos;
        for (int i = 0; i < startSize; i++)
        {
            GameObject _shooes = Instantiate(ObjToPooling);
            PoolingToListToremove.Add(_shooes);
            _shooes.transform.localRotation = Quaternion.Euler(0, 0, 0);
            _shooes.transform.localPosition = currentPos;
            currentPos -= new Vector3(0, .5f, 0);
            _shooes.transform.parent = Player.transform;
            poolingObjs.Enqueue(_shooes);
            _shooes.SetActive(false);
            counter = poolingObjs.Count;
        }
    }
    public GameObject getShooes()
    {
        if (poolingObjs.Count != 0)
        {
            GameObject _shooes = poolingObjs.Dequeue();
            _shooes.SetActive(true);
            _shooes.transform.localRotation = Quaternion.Euler(0, 0, 0);
            counter++;
            return _shooes;
        }
        else
        {
            Vector3 _startpos = Player.position + counter * new Vector3(0, -.5f, 0);
            Vector3 currentPos = new Vector3(0, -.5f, 0) + _startpos;
            for (int i = 0; i < 1; i++)
            {
                counter++;
                Debug.Log("counter" + counter);
                GameObject _shooes = Instantiate(ObjToPooling);
                PoolingToListToremove.Add(_shooes);
                _shooes.transform.localPosition = currentPos;
                currentPos -= new Vector3(0, .5f, 0);
                poolingObjs.Enqueue(_shooes);
                _shooes.SetActive(false);
            }
            GameObject shooes = poolingObjs.Dequeue();           
            shooes.SetActive(true);
            shooes.transform.parent = Player.transform;
            shooes.transform.localRotation = Quaternion.Euler(0, 0, 0);
            return shooes;
        }
    }
    public void ActiveAgain()
    {
        for (int i = 0; i < PoolingToListToremove.Count; i++)
        {
           
        }
    }
    public void ReturnShooes(GameObject _shoes)
    {
       // PoolingToListToremove.Remove(_shoes);
        poolingObjs.Enqueue(_shoes);
        _shoes.SetActive(false);
    }

   
}
