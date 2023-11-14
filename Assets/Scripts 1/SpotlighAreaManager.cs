using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlighAreaManager : MonoBehaviour
{
    [SerializeField] private PlayerManager player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("alla luce");
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(new(Random.Range(-2.5f, -1.2f), 0f, Random.Range(-2.5f, -1.2f)), ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("al buio");
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(new(1f, 0f, 1f), ForceMode.Impulse);
        }
    }
}