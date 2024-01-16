using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class MapLocation
{
    public int x;
    public int z;

    public MapLocation(int _x, int _z)
    {
        x= _x;
        z= _z;
    }

    public Vector2 ToVector()
    {
        return new Vector2(x,z);
    }

    public static MapLocation operator +(MapLocation a, MapLocation b)
        => new MapLocation (a.x + b.x, a.z + b.z);

    public bool Equals(MapLocation other)
    {
        if (x == other.x && z == other.z)
        {
            return true;
            // return (x == other.x && z == other.z);
        }
        return false;
    }
}
