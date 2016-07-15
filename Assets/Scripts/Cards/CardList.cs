using UnityEngine;
using System.Collections.Generic;

public class CardList : MonoBehaviour {
    public static CardList Instance { get; private set; }

    public int CardAmount {
        get {
            return cards.Count;
        }
    }

    private List<GameObject> cards = new List<GameObject>();

    public void AddCard(GameObject card) {
        cards.Add(card);
        card.transform.parent = transform;
        card.SetActive(false);
    }

    public GameObject GetCard(int pos) {
        var card = Instantiate(cards[pos]);
        card.name = card.name.Remove(card.name.Length - 7, 7);
        Debug.Log(card.name);
        return card;
    }

    void Awake() {
        if (!Instance)
            Instance = this;
        else
            Logger.LogError(this, "Awake", "Instance already exists");
    }
}
