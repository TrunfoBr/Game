using UnityEngine;
using System.Collections;

public class IA : SinglePlayer {

    public float time = 5f;
    private Timer timer;

    void Start() {
        timer = new Timer(time);
    }

	public override void AddCard(GameObject card) {
        base.AddCard(card);
        card.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    protected override void PlayerUpdate() {
        if (timer.IsOver()) {
            hasDecidedAttribute = true;
            attributeToPlay = Random.Range(0,4);
            timer.Reset();
        }
        else {
            timer.Run();
        }
    }
}
