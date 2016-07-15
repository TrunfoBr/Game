﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SinglePlayer : MonoBehaviour {

    public bool turn = false;
    public GameObject hand;
    public List<GameObject> my_deck = new List<GameObject>();

    protected bool hasDecidedAttribute = false;
    protected int attributeToPlay;
    
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

        if (turn) {
            PlayerUpdate();
            if (hasDecidedAttribute) {
                Logger.Log(this, "Update", "attribute to play was decided: " + attributeToPlay);
                // TODO: Do end of turn calculations
                hasDecidedAttribute = false;
                TurnManager.Instance.EndMyTurn();
            }
        }
    }

    protected virtual void PlayerUpdate() {}
}