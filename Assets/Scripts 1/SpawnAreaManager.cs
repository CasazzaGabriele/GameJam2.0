using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnAreaTransform;

    // Start is called before the first frame update
    private void Start()
    {
        DisactiveAllSpawnArea();
        RandomizeArea();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void RandomizeArea()
    {
        for (int i = 0; i < 5; i++)
        {
            spawnAreaTransform[Random.Range(0, spawnAreaTransform.Length)].SetActive(true);
        }
    }

    public void DisactiveAllSpawnArea()
    {
        for (int i = 0; i < spawnAreaTransform.Length; i++)
        {
            spawnAreaTransform[i].SetActive(false);
        }
    }
}