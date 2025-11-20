using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] blocks; // 테트로미노 프리팹 배열

    void Start()
    {
        SpawnNewBlock();
    }

    public void SpawnNewBlock()
    {
        int random = Random.Range(0, blocks.Length);
        Instantiate(blocks[random], new Vector3(5, 20, 0), Quaternion.identity);
    }
}