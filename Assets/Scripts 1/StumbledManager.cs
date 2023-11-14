using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumbledManager : MonoBehaviour
{
    public GameObject[,] stumbledPrefabMatrix;

    private int matrixRows;
    private int matrixColumns;

    // Start is called before the first frame update
    private void Start()
    {
        matrixRows = stumbledPrefabMatrix.GetLength(0);
        matrixColumns = stumbledPrefabMatrix.GetLength(1);
        DisableStumbPref();
        EnableRandomPref(3);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //#########################################################################
    //                            CUSTOM FUNCTION
    //#########################################################################

    private void DisableStumbPref()
    {
        for (int i = 0; i < matrixRows; i++)
        {
            for (int x = 0; x < matrixColumns; x++)
            {
                stumbledPrefabMatrix[i, x].SetActive(false);
            }
        }
    }

    private void EnableRandomPref(int index)
    {
        if (index <= 0)
        {
            return;
        }

        int x = Random.Range(0, matrixRows);
        int y = Random.Range(0, matrixColumns);

        if (!stumbledPrefabMatrix[x, y].activeSelf)
        {
            stumbledPrefabMatrix[x, y].SetActive(true);
        }
        else
        {
            EnableRandomPref(index - 1);
        }
    }
}