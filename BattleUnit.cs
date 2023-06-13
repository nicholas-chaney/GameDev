using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    public Enemy Slime;
    public Enemy player;
    public void Setup(bool Player, Enemy enemy)
    {
        if (Player == false)
        {
            Slime = enemy;
            GetComponent<Image>().sprite = enemy.EnemySprite;
        }
        else
        {
            GetComponent<Image>().sprite = player.EnemySprite;
        }
    }
}
