using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    void Start()
    {
        Pin[] pins = FindObjectsOfType<Pin>();
        Pin.pinCounter = 0;
        Shuffle(pins);

        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].pinOrderNumber = i;
        }
    }

    private void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
