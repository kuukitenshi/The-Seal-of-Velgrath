using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitionManager
{
    public static void TransitionToScene(string sceneName)
    {
        GameState.LastScene = SceneManager.GetActiveScene().name;
        Debug.Log($"SceneTransition {GameState.LastScene} -> {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
