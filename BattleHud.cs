using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] HPBar hpbar;

    
    public void SetData(Enemy enemy)
    {
        nameText.text = enemy.name;
        levelText.text = enemy.level.ToString();
        hpbar.SetHP((float) enemy.health / enemy.maxhealth);
    }

    public IEnumerator UpdateHP(Enemy enemy)
    {
        yield return hpbar.SetHPSmooth((float)enemy.health / enemy.maxhealth);

    }
}
