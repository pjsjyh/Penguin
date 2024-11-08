using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMonsterSpawn : MonoBehaviour
{
    public List<GameObject> waveMonsterSpawn;

    public Transform[] spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();

        spawn(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spawn(int num)
    {
        for (int i = 1; i < spawnPoint.Length; i++)
        {

            Instantiate(waveMonsterSpawn[num], spawnPoint[i].position, Quaternion.identity);
        }

    }
}
