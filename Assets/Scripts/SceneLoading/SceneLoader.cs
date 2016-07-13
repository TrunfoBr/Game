using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadScene(string scene) {
        LoadSceneStatic(scene);
    }

    public void LoadScene(int sceneId) {
        LoadSceneStatic(sceneId);
    }

    public void LoadNextScene() {
        LoadNextSceneStatic();
    }

    static public void LoadSceneStatic(string scene) {
        SceneManager.LoadScene(scene);
    }

    static public void LoadSceneStatic(int sceneId) {
        SceneManager.LoadScene(sceneId);
    }

    static public void LoadNextSceneStatic() {
        int nextSceneId = GetNextSceneId();
        if (IsLastScene(nextSceneId))
            nextSceneId = 0;
        LoadSceneStatic(nextSceneId);
    }

    private static bool IsLastScene(int sceneId) {
        return sceneId >= SceneManager.sceneCountInBuildSettings;
    }

    private static int GetNextSceneId() {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }
}
