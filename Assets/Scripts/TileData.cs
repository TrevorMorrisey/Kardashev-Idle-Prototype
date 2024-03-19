using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    public Vector2Int position;
    public bool isTaken;
    public bool isRiver;

    public TileData(Vector2Int position, bool isTaken, bool isRiver)
    {
        this.position = position;
        this.isTaken = isTaken;
        this.isRiver = isRiver;
    }

}