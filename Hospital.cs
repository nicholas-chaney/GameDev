using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hospital : MonoBehaviour
{

    public GameObject HospitalPanel;
    public bool HospitalOpen = false;
    public TextMeshProUGUI goldAmmount;
    public Enemy Player;
    int gold;
    public GameObject Shop;
    public TextMeshProUGUI errorcode;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player && HospitalOpen == false)
        {
            HospitalOpen = true;
            HospitalPanel.SetActive(true);
            errorcode.enabled = false;
        }

    }

    public void buyHealt(int Health)
    {
        gold = int.Parse(goldAmmount.text);
        if(Health == 100)
        {
            
            if(int.Parse(goldAmmount.text) >= 10)
            {
                if (Player.health <= Player.maxhealth - 100)
                {
                    Player.health += 100;
                    Shop.GetComponent<Shop>().RemoveGold(10);
                    UpdateGold();
                }
                else
                {
                    errorcode.enabled = true;

                    errorcode.text = "Your health can't increase by another 100.";
                }
            }
            else
            {
                errorcode.enabled = true;

                errorcode.text = "You do not have enough gold";
            }
        }
        
    }

    private void UpdateGold()
    {

        goldAmmount.text = gold.ToString();
    }
    public void closeHospital()
    {
        HospitalPanel.SetActive(false);
        HospitalOpen = false;
    }
}
