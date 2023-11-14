using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //------------------------------------
    // variabili per la UI

    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text score;
    [SerializeField] private GameObject GameOverPannel;
    [SerializeField] private Slider slide;

    //-------------------------------------------
    //variablie di tipo playerManager per pescrmi i dati che mi servono

    [SerializeField] private PlayerManager player;

    private void Start()
    {
        GameOverPannel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.gameOver)
        {
            GameOverPannel.SetActive(true);
        }
        else
        {
            timer.SetText($"{(int)player.timer}");
            score.SetText($"{player.levelNois}");
            slide.value = player.levelNois / 100;
        }
    }
}