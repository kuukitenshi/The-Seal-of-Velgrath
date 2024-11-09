using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDialogue : MonoBehaviour
{

    private Dialogue _dialogue;

    void Start()
    {
        _dialogue = new Dialogue();
        _dialogue.name = "NPC";
        _dialogue.sentences = new string[]{
            "In adipisicing sint ut laboris nisi tempor nostrud. Amet mollit eu minim Lorem ipsum minim exercitation id eu ullamco reprehenderit tempor pariatur sunt. Esse amet esse labore ad et nostrud exercitation sint ad nulla ullamco reprehenderit.",
            "You are amazing",
            "Kill all the slimes please!"
        };
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
        }
    }
}
