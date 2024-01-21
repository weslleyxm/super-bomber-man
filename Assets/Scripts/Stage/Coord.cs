using System;
using UnityEngine;

[Serializable]
public class Coord
{
    public int x { get{ return _x;} }
    public int y { get { return _y; } }

    [SerializeField] int _x;
    [SerializeField] int _y; 
     
    public Coord(int x, int y)
    {
        this._x = x; 
        this._y = y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Coord))
            return false;

        Coord other = (Coord)obj;
        return x == other.x && y == other.y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}