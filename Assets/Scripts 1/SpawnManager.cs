using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefToSpawn;
    [SerializeField] private PlayerManager player;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
        SpawnObject();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SpawnObject()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject pref = prefToSpawn[Random.Range(0, prefToSpawn.Length)];
            Vector3 posSpawn = NewPos();
            GameObject spawnedPref = Instantiate(pref, posSpawn, Quaternion.identity);
        }
    }

    private Vector3 NewPos()
    {
        Vector3 newpos = new(Random.Range(-3.2f, 3.2f), 0, Random.Range(-4.2f, 4.2f));
        return newpos;
    }
}