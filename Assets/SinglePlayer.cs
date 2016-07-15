using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SinglePlayer : MonoBehaviour {

    public GameObject hand;
    public List<GameObject> my_deck = new List<GameObject>();

    public virtual void AddCard(GameObject card) {
        my_deck.Add(card);
        card.transform.parent = transform;
        card.transform.position = transform.position;
        card.transform.localScale = transform.localScale;
    }

    void Update() {
        if (hand != my_deck[0]) {
            hand = my_deck[0];
            hand.SetActive(true);
        }
    }
}
