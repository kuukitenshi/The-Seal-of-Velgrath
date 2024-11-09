using UnityEngine;

public static class OverlaySystem
{
    public static void OpenOverlay(GameObject gameObject)
    {
        gameObject.SetActive(true);
        Debug.Log(gameObject);
    }

    public static void CloseOverlay(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
