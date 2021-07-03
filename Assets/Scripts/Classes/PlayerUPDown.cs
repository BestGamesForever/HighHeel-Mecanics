using UnityEngine;

public class PlayerUPDown:MonoBehaviour
{
    [SerializeField] Transform player;
  
    public void CalculateUP()
    {
      //  PlayerMovement.gravity = 0;

        Vector3 playerpos = player.transform.localPosition;      
        playerpos.y += 0.5f;     
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = playerpos;
        player.GetComponent<CharacterController>().enabled = true;

    }
    public void Calculatedown()
    {
        if (player.position.y<=.8)
        {
            Debug.Log("FinishGame");
        }
        else
        {
            Debug.Log("Player Down");
            Vector3 playerpos = player.transform.localPosition;
            playerpos.y -= 0.5f;
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = playerpos;
            player.GetComponent<CharacterController>().enabled = true;
        }
       
    }
}
