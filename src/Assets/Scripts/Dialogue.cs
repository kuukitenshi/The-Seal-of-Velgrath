using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

    public Dialogue(string name, string[] sentences)
    {
        this.name = name;
        this.sentences = sentences;
    }

    public Dialogue() { }
}
