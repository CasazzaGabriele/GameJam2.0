using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;

    // Start is called before the first frame update
    private void Start()
    {
        vCam.m_Priority = 0;
    }

    // Update is called once per frame
    // to change visual change the priority of the second cam
    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            vCam.m_Priority = 10;
        }
        else if (Input.GetKeyDown("g"))
        {
            vCam.m_Priority = 0;
        }
    }
}