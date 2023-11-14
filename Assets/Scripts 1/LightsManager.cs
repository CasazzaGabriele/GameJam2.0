using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    [SerializeField] private PlayerManager player;

    private int diff = 3;

    // Start is called before the first frame update
    private void Start()
    {
        // in start spengo tutte le luci in scenza
        turnLightsOff();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.levelNois <= 50)
        {
            Invoke("randomizeLightsOn", 2f);
        }
    }

    // funzione custom per l'attivazione randomica delle luci
    public void randomizeLightsOn()
    {
        if (player.isWinner == true || player.gameOver == true)
        {
            return;
        }
        for (int i = 0; i < diff; ++i)
        {
            int x = Random.Range(0, lights.Length); // gernero un indice randomico

            // mi accendo la luce corrispondente all indice e il suo relativo figlio sphere collider (trigger)
            lights[x].SetActive(true);
        }
        Invoke("turnLightsOff", 4f);
    }

    // funzione per spegner le luci
    public void turnLightsOff()
    {
        for (int i = 0; i < lights.Length; ++i)
        {
            // spengo le luci
            lights[i].SetActive(false);
        }
    }
}