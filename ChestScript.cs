using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public bool isOpen =false;
    public Animator animator;
    [SerializeField]
    public Collectables fishingpole;
    public Player character;
    public GameObject shopTrigger;
    
    public void OpenChest(int ChestNumber)
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest is now open");
            if(ChestNumber == 1)
            {
                character.inventory.Add(fishingpole);
                Debug.Log("You Opened Chest 1");
                
            }
            if(ChestNumber == 2)
            {
                //adds 10 gold
                return;
            }
        }
        
    }
}
