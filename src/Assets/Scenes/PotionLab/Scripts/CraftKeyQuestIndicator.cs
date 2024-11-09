using UnityEngine;

public class CraftKeyQuestIndicator : MonoBehaviour
{
    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.CraftKey.Id)
        {
            gameObject.SetActive(false);
        }
    }
}
