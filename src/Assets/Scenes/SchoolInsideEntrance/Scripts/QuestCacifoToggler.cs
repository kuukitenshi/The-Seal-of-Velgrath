using UnityEngine;

public class QuestCacifoToggler : MonoBehaviour
{
    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.OpenLocker.Id)
        {
            gameObject.SetActive(false);
            return;
        }
    }
}
