using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{

    public GameObject top;
    public GameObject bottom;

    public GameObject top_blue;

    public GameObject bottom_blue;

    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            top.SetActive(false);
            bottom.SetActive(false);
            top_blue.SetActive(true);
            bottom_blue.SetActive(true);
        });

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            top.SetActive(true);
            bottom.SetActive(true);
            top_blue.SetActive(false);
            bottom_blue.SetActive(false);
        }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     GetComponent<SpriteRenderer>().color = new Color(0f, 0.837f, 0.9245283f, 1f);
        // }
        // else if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     GetComponent<SpriteRenderer>().color = Color.white;
        // }
    }
}
