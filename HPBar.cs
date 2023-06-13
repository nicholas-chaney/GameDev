using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);

    }

    public IEnumerator SetHPSmooth(float newhp)
    {
        float curHp = health.transform.localScale.x;
        float changeAmt = curHp - newhp;

        while(curHp - newhp > Mathf.Epsilon)
        {
            curHp -= changeAmt * Time.deltaTime;
            health.transform.localScale = new Vector3(curHp, 1f);
            yield return null;

        }
        health.transform.localScale = new Vector3(newhp, 1f);

    }
}
