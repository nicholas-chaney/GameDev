using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Move", menuName = "Create New Move")]
public class Moves : ScriptableObject
{
    [SerializeField] string Name;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    

    public string MoveName
    {
        get { return Name; }
    }

    public int MovePower
    {
        get { return power; }
    }

    public int MoveAccuracy
    {
        get { return accuracy; }
    }
}
