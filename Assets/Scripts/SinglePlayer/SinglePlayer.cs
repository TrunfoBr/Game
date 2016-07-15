using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SinglePlayer : MonoBehaviour {

    public bool turn = false;
    public GameObject hand;
    public List<GameObject> my_deck = new List<GameObject>();
    public Text cardAmount;

    protected bool hasDecidedAttribute = false;
    protected int attributeToPlay;
    
    public virtual void AddCard(GameObject card) {
        my_deck.Add(card);
        card.transform.parent = transform;
        card.transform.position = transform.position;
        card.transform.localScale = transform.localScale;
    }

    void Update() {
        cardAmount.text = my_deck.Count.ToString() + " Cards";
        if (my_deck.Count == 0) {
            EndGame.Instance.NotifyDeath();
            return;
        }

        if (hand != my_deck[0]) {
            hand = my_deck[0];
            hand.SetActive(true);
        }

        if (turn) {
            PlayerUpdate();
            if (hasDecidedAttribute) {
                Logger.Log(this, "Update", "attribute to play was decided: " + attributeToPlay);
                EndOfTurn.Instance.RequestAttributeComparison(attributeToPlay);
                hasDecidedAttribute = false;
            }
        }
    }

    protected virtual void PlayerUpdate() {}
}
