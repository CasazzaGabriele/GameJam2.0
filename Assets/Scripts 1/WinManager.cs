using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        print("hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SetisWinner(true);
        }
    }
}