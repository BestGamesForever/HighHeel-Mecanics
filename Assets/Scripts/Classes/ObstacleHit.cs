using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public Poolingmanager poolingmanager;
    [SerializeField] PlayerUPDown _playerUpDown;

    private void OnTriggerEnter(Collider other)
    {
      
       if ((other.gameObject.tag == "Player") || (other.gameObject.tag == "Heel"))
       {
           gameObject.GetComponent<Collider>().enabled = false;
           gameObject.SetActive(false);
           Debug.Log("Hit");
           _playerUpDown.Calculatedown();
            poolingmanager.ReturnShooes(other.gameObject);
            poolingmanager.counter--;
            Debug.Log($"counter {poolingmanager.counter}");
       }
       
    }
  
}
