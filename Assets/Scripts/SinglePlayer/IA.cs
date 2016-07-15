using UnityEngine;
using System.Collections;

public class IA : SinglePlayer {

	public override void AddCard(GameObject card) {
        base.AddCard(card);
        card.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
}
