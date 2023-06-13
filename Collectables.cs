using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectables : MonoBehaviour
{

    public CollectableType type;
    public Sprite icon;
    public GameObject gameObj;

    public bool fishing;
    public Collectables fishingPole;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.GetComponent<Player>();
        if(player) {            
            player.inventory.Add(this);
            Destroy(this.gameObject);
            if(type == CollectableType.Axe)
            {
                gameObj.GetComponent<axeman>().recievedaxe();

            }
            if(type == CollectableType.FishingPole)
            {
                //player.inventory.Add(fishingPole);
                gameObj.GetComponent<Dialogue>().StartDialogue(3);

            }
            
        }
        

    }




}

public enum CollectableType
{
    NONE, STICKS, Rocks, Axe, Dagger, FishingPole, GoldFish, ClownFish, SwordFish, Shark, Crab
}