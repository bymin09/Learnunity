using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public List<MapLocation> directions = new List<MapLocation>()
    {
        new MapLocation(1,0),
        new MapLocation(0,1),
        new MapLocation(-1,0),
        new MapLocation(0,-1),
    };
    public int width = 30;
    public int depth = 30;
    public byte[,] map;
    public int scale = 6;
    public Transform Terrain;

    void Start()
    {
        
    }

    public void BuildGenerator()
    {
        initialiseMap();
        Generate(5, 5);
        DrawMap();
    }

    void initialiseMap()
    {
        map = new byte[width,depth];
        for(int z = 0; z < depth; z++)
        {
            for(int x = 0; x < width; x++)
            {
                map[x, z] = 1; //1은 벽. 0은 통로
            }
        }
    }

    public void Generate(int x, int z)
    {
        // 4방위 중 2방위 이상이 복도일 경우 || 자인이 복도일 때를 추가
        if(CountSquareNeighbours(x, z) >= 2 || map[x,z] == 0)
        {
            return;
        }

        map[x, z] = 0;

        directions.Shuffle();

        Generate(x + directions[0].x, z + directions[0].z); //6,5
        Generate(x + directions[1].x, z + directions[1].z); //5,6
        Generate(x + directions[2].x, z + directions[2].z); //4,5
        Generate(x + directions[3].x, z + directions[3].z); //5,4
    }

    /// <summary>
    /// 4방위 복도를 검색한다
    /// </summary>
    /// <param name = "x"></param>
    /// <param name = "z"></param>
    /// <returns></returns>

    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x - 1, z] == 0) count++;
        if (map[x + 1, z] == 0) count++;
        if (map[x, z + 1] == 0) count++;
        if (map[x, z - 1] == 0) count++;
        return count;
    }

    void DrawMap()
    {
        for(int z = 0; z < depth; z++)
        {
            for(int x = 0; x < width; x++)
            {
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                    wall.transform.parent = Terrain;
                    wall.name = x + "." + z;
                }
            }
        }
    }

}
