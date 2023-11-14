using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private Rigidbody rb;
    private bool isOverPrefab;

    private PlayerManager player;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerManager>();
            player.levelNois -= 10;
            print("-10");
            print(player.levelNois);
        }
    }
}