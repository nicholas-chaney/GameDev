using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public GameObject shop;

    public List<Slots_UI> slots = new List<Slots_UI>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);

        }
    }

    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(Collectables item)
    {

        if (player.inventory.checkinventory(item) == false)
        {
            shop.GetComponent<Shop>().NoItem();
            Debug.Log("not in inventory");
        }
        else
        {
            player.inventory.Remove(item);
            Debug.Log("in inventory");
        }
        Refresh();
    
        
    }
}
