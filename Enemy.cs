using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Data", menuName ="Enemy Data", order = 50)]
public class Enemy : ScriptableObject
{
    public string EnemyType = "Enemy Type";
    public Sprite EnemySprite;
    public int level = 0;
    public float health = 0;
    public float maxhealth = 0;
    public int attack = 0;
    public int defense = 0;
    public List<Moves> moves;

    public bool TakeDamage(Moves move, Enemy attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.level + 10) / 250f;
        float d = a * move.MovePower * ((float)attacker.attack / defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        if (attacker.health > 0)
        {
            health -= damage;
        }
        if(health > 0)
        {
            return false;

            
        }
        else
        {
            health = 0;
            return true;
            
        }
    }

    public Moves GetRandomMove()
    {
        
            int r = Random.Range(0, moves.Count);
            return moves[r];
        
    }
}
