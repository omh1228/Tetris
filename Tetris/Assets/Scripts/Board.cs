using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[width, height];

    public static bool InsideBoard(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    }

    public static void AddToGrid(Transform block)
    {
        foreach (Transform child in block)
        {
            Vector2 pos = Round(child.position);
            grid[(int)pos.x, (int)pos.y] = child;
        }
    }

    public static Vector2 Round(Vector2 pos) =>
        new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
}
