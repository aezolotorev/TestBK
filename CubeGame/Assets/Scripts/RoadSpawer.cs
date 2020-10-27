using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawer : MonoBehaviour
{
    public GameObject[] RoadPrefabs;
    public GameObject StartBlock;
    public GameObject[] Obstacles;
    float blockXPos = 0;
    int blockcount = 2;
    float blocklenhgt = 0;
    int safezone = 170;

    public Transform PlayerTransf;
    List<GameObject> CurrentBlock = new List<GameObject>();
    List<GameObject> CurrentObstacles = new List<GameObject>();



    void Start()
    {
        blockXPos = StartBlock.transform.position.x;
        blocklenhgt = StartBlock.GetComponentInChildren<BoxCollider>().bounds.size.x;
        for(int i =0; i<blockcount; i++)
        {
            SpawnBlock();
        }
         
    }

    

    void CheckforSpawn()
    {
        if (PlayerTransf.position.x - blocklenhgt-safezone> (blockXPos - blockcount * blocklenhgt))
        {
            SpawnBlock();
            DestroyBlock();
        }
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlock[0].gameObject);
        CurrentBlock.RemoveAt(0);

    }
    private void SpawnBlock()
    {
        GameObject block = Instantiate(RoadPrefabs[UnityEngine.Random.Range(0, RoadPrefabs.Length)], transform);
        blockXPos += blocklenhgt;
        block.transform.position = new Vector3(blockXPos, StartBlock.transform.position.y, StartBlock.transform.position.z);
        for (int i = 0; i < 10; i++)
        {
            GameObject obstacle = Instantiate(Obstacles[UnityEngine.Random.Range(0, Obstacles.Length)], transform);
            obstacle.transform.parent = block.transform;
            obstacle.transform.position = new Vector3((blockXPos- blocklenhgt) + i*25, StartBlock.transform.position.y, StartBlock.transform.position.z);            
            CurrentObstacles.Add(obstacle);
        }
            CurrentBlock.Add(block);
        }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckforSpawn();
    }
}
