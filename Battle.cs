using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Battle : MonoBehaviour
{
    public Enemy[] enemies;
    public BattleSystem bs;
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject infoBar;
    void StartBattle(Enemy enemy)
    {
        if (enemy.EnemyType == "Slime")
        {
            Debug.Log("Battle Started");
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("CameraPosition", 1);
            cam2.SetActive(true);
            infoBar.SetActive(false);
            cam1.SetActive(false);
            
            bs.Battle(enemy);
        }
        if (enemy.EnemyType == "Crab")
        {
            Debug.Log("Battle Started");
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("CameraPosition", 1);
            cam2.SetActive(true);
            infoBar.SetActive(false);
            cam1.SetActive(false);

            bs.Battle(enemy);
        }
    }

}
