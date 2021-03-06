﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dealer : MonoBehaviour {

    private CardList deck;
    public List<SinglePlayer> players;

	void Start () {
        deck = CardList.Instance;

        int[] index = new int[deck.CardAmount];
        for (int i=0; i<deck.CardAmount; i++) {
            index[i] = i;
        }
        System.Array.Sort(index, RandomSort);

        for (int i=0; i<deck.CardAmount; i += players.Count) {
            for (int j=0; j<players.Count; j++) {
                var card = deck.GetCard(index[i + j]);
                card.name = card.name.Remove(card.name.Length - 7, 7);
                players[j].AddCard(card);
            }
        }
	}

    public int RandomSort(int a, int b) {
        return Random.Range(-1, 2);
    }
}
