using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float fallTime = 0.8f;
    private float previousTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!IsValidMove())
                transform.position -= Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!IsValidMove())
                transform.position -= Vector3.right;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
            if (!IsValidMove())
                transform.Rotate(0, 0, -90);
        }

        // 자동 낙하 or 아래키 가속
        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += Vector3.down;
            if (!IsValidMove())
            {
                transform.position -= Vector3.down;

                Board.AddToGrid(transform);
                FindObjectOfType<GameManager>().SpawnNewBlock();
                enabled = false;
            }
            previousTime = Time.time;
        }
    }

    bool IsValidMove()
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = Board.Round(child.position);

            if (!Board.InsideBoard(pos))
                return false;

            if (Board.grid[(int)pos.x, (int)pos.y] != null)
                return false;
        }
        return true;
    }
}


