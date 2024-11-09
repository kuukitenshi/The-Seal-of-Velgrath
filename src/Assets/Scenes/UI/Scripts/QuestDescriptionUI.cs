using TMPro;
using UnityEngine;

public class QuestPanelUI : MonoBehaviour
{
    private TMP_Text _description;

    void Start()
    {
        _description = GetComponent<TMP_Text>();
    }


    void Update()
    {
        if (GameState.CurrentQuest != null)
        {
            _description.text = GameState.CurrentQuest.Description;
        }
    }
}
