using UnityEngine;
using System.Collections;

public class CardLoadingMenu : MonoBehaviour {

    public CardFactory cardFactory;
    public string sceneToLoadOnEnd;

    void Update() {
        if (cardFactory.isDone)
            SceneLoader.LoadSceneStatic(sceneToLoadOnEnd);
    }
}
