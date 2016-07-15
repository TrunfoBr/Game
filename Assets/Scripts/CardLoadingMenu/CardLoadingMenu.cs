using UnityEngine;
using UnityEngine.UI;

public class CardLoadingMenu : MonoBehaviour {

    public CardFactory cardFactory;
    public string sceneToLoadOnEnd;
    public Text text;

    void Update() {
        text.text = cardFactory.progress.ToString() + "%";
        if (cardFactory.isDone)
            SceneLoader.LoadSceneStatic(sceneToLoadOnEnd);
    }
}
