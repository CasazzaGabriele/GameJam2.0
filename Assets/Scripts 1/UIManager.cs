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
    [SerializeField] public Slider slide;

    //-------------------------------------------
    //variablie di tipo playerManager per pescrmi i dati che mi servono

    [SerializeField] private PlayerManager player;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timer.SetText($"{(int)player.timer}");
        slide.value = player.levelNois;
    }
}