using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageSettings", menuName = "Remake/StageSettings")]
public class StageSettings : ScriptableObject 
{
    public Sprite floorBlock, destructibleBlock, solidBlock, borderBlock;
     
    public int column = 17, row = 15; 
    public float blockSpacing = 0.7f; 

    public List<Coord> forbiddenDestructiblePositions = new List<Coord>()
    {
        new Coord(2, 12),
        new Coord(3, 12),
        new Coord(2, 11),
        new Coord(14, 11),
        new Coord(14, 12),
        new Coord(13, 12),
        new Coord(13, 2),
        new Coord(14, 2),
        new Coord(14, 3),
        new Coord(3, 2),
        new Coord(2, 2),
        new Coord(2, 3),
        new Coord(7, 8),
        new Coord(8, 8),
        new Coord(9, 8),
        new Coord(8, 7),
        new Coord(8, 9),
    };
}
