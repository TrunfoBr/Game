using UnityEngine;
using System.Collections.Generic;

public class CardList : MonoBehaviour {
    public static CardList Instance { get; private set; }

    private List<GameObject> cards = new List<GameObject>();

    public void AddCard(GameObject card) {
        cards.Add(card);
        card.transform.parent = transform;
    }

    public GameObject GetCard(int pos) {
        return Instantiate(cards[pos]);
    }

    void Awake() {
        if (!Instance)
            Instance = this;
        else
            Logger.LogError(this, "Awake", "Instance already exists");
    }
}
