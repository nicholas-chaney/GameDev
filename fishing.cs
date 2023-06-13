using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishing : MonoBehaviour
{
    public GameObject gameObj;
    public GameObject player;
    public bool hasPole = false;
    //private int rand = Random.Range(1, 3);
    public Collectables fish;
    public Collectables rock;
    public Collectables stick;



    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && (Input.GetKeyDown(KeyCode.Space)) && hasPole == true)
        {
            //stick
            if (Random.Range(1, 3) == 1)
            {
                gameObj.GetComponent<FishingDialogue>().StartDialogue(1);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(rock);
            }
            else if(Random.Range(1, 3) == 2)
            {
                gameObj.GetComponent<FishingDialogue>().StartDialogue(2);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(stick);
            }
            else if (Random.Range(1, 4) == 3)
            {
                gameObj.GetComponent<FishingDialogue>().StartDialogue(3);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(fish);
            }
        }
    }
    public void GetFishingPole()
    {
        hasPole = true;
    }
}
