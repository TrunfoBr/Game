using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dealer : MonoBehaviour {

    private CardList deck;
    public List<SinglePlayer> players;

	void Start () {
        deck = CardList.Instance;
        for (int i=0; i<deck.CardAmount; i += players.Count) {
            for (int j=0; j<players.Count; j++) {
                players[j].AddCard(deck.GetCard(i+j));
            }
        }
	}
}
