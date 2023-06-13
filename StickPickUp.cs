using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StickPickUp : MonoBehaviour
{
    public bool isPicked;
    [SerializeField]
    public int StickNumber;
    public Tilemap tilemap;
    public Tile grass;
    public Vector3Int position;
    void Paint(Vector3Int position)
    {
        tilemap.SetTile(position, grass);
    }

    public void PickupStick()
    {
        if (!isPicked)
        {
            isPicked = true;
            Debug.Log("Stick Picked Up");
            Paint(position);
            /*if(StickNumber == 1)
            {
                position.Set(-2, -2, 0);
                Debug.Log(position);
                Paint((position));
            }
            else if (StickNumber == 2)
            {
                position.Set(-6, -3, 0);
                Debug.Log(position);
                Paint((position));
            }
            */

        }

    }
}
