using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D hitbox;
    public int damageAmmount = 1;
    public Enemy Slime;
    public float health = 20;
    public float level = 1;
    //public BattleSystem BS;
    
    private void Start()
    {
        if (hitbox == null)
        {
            Debug.Log("check hit boxes");
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       // collision.collider.SendMessage("Battle");
    }

}
