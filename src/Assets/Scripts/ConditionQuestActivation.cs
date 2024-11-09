using UnityEngine;

public class ConditionQuestActivation : MonoBehaviour
{
    [SerializeField]
    private string _requiredQuestId;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != _requiredQuestId)
        {
            gameObject.SetActive(false);
        }
    }
}
