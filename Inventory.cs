using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Inventory
{
    


    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;
        
        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }
        public bool CanAddItem()
        {
            if(count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Collectables item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if(count == 0)
                {
                    icon = null;
                    type = CollectableType.NONE;
                }
            }
        }

    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i <numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectables item)
    {
        foreach(Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public bool checkinventory(Collectables item)
    {
        for (int j = 0; j <= 9; j++)
        {

            if (item.type == CollectableType.STICKS)
        {
                if (slots[j].type == item.type)
                {
                    return (true);
                    //Remove(item);
                }
                
            }
            if (item.type == CollectableType.Rocks)
        {
                
                    if (slots[j].type == item.type)
                    {
                        return (true);
                        //Remove(item);
                    }
                    
                
        }
            if (item.type == CollectableType.GoldFish)
            {

                if (slots[j].type == item.type)
                {
                    return (true);
                    //Remove(item);
                }


            }
            if (item.type == CollectableType.Axe)
            {

                if (slots[j].type == item.type)
                {
                    return (true);
                    //Remove(item);
                }


            }
            if (item.type == CollectableType.FishingPole)
            {

                if (slots[j].type == item.type)
                {
                    return (true);
                    //Remove(item);
                }


            }


        }
        return (false);
    }

    public bool HasFiveFish(Collectables goldfish)
    {
        for(int i = 0; i<= 9; i++)
        {
            if (slots[i].type == CollectableType.GoldFish)
            {
                if(slots[i].count >= 5)
                {
                    return (true);
                }

            }
        }
        return (false);
    }

    public void Remove(Collectables item)
    {

        if (item.type == CollectableType.STICKS)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (slots[i].type == CollectableType.STICKS)
                {
                    slots[i].RemoveItem();

                }

            }
        }
        else if (item.type == CollectableType.Rocks)
        {
            for (int i = 0; i <= 9; i++)
            {

                if (slots[i].type == CollectableType.Rocks)
                {
                    slots[i].RemoveItem();

                }
            }
        }
        else if (item.type == CollectableType.Axe)
        {
            for (int i = 0; i <= 9; i++)
            {

                if (slots[i].type == CollectableType.Axe)
                {
                    slots[i].RemoveItem();

                }
            }
        }
        else if (item.type == CollectableType.FishingPole)
        {
            for (int i = 0; i <= 9; i++)
            {

                if (slots[i].type == CollectableType.FishingPole)
                {
                    slots[i].RemoveItem();

                }
            }
        }
        else if (item.type == CollectableType.GoldFish)
        {
            for (int i = 0; i <= 9; i++)
            {

                if (slots[i].type == CollectableType.GoldFish)
                {
                    slots[i].RemoveItem();

                }
            }
        }



    }
    
}
    
