using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SeaFishing : MonoBehaviour
{
    public GameObject FishingDialogue;
    public GameObject player;
    public bool hasPole = false;

    public Collectables crab;
    public Collectables shark;
    public Collectables swordFish;
    public Collectables clownFish;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
    if (player && (Input.GetKeyDown(KeyCode.Space)) && hasPole == true)
    {
            //stick
            if (Random.Range(1, 7) == 1)
            {
                FishingDialogue.GetComponent<FishingDialogue>().StartDialogue(4);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(crab);
            }
            else if (Random.Range(1, 7) == 2)
            {
                FishingDialogue.GetComponent<FishingDialogue>().StartDialogue(5);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(shark);
            }
            else if (Random.Range(1, 7) == 3)
            {
                FishingDialogue.GetComponent<FishingDialogue>().StartDialogue(6);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(swordFish);
            }
            else if (Random.Range(1, 7) == 4)
            {
                FishingDialogue.GetComponent<FishingDialogue>().StartDialogue(7);
                player.GetComponent<PlayerMovement>().Fishing(true);
                player.inventory.Add(clownFish);
            }
            else
            {
                FishingDialogue.GetComponent<FishingDialogue>().StartDialogue(0);
            }
    }
}
public void GetFishingPole()
{
hasPole = true;
}
}
