using UnityEngine;

public class BlackScreenCloser : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(StoryScript.GoToBathroom);
        }
    }
}
