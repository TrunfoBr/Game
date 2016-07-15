using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MainDeck : NetworkBehaviour {

    public static MainDeck Instance;
    private int cardAmount = 0;
    private bool deckReady = false;

    public override void OnStartServer() {
        var cards = CardList.Instance;
        for (int i = 0; i < cards.CardAmount; i++) {
            cardAmount++;
            var card = cards.GetCard(i);
            card.transform.parent = transform;
            NetworkServer.Spawn(card);
        }
        deckReady = true;
    }

    public bool stillHasCards() {
        return cardAmount > 0;
    }

    public void GiveCardTo(GameObject player) {
        if (!deckReady)
            return;
        Logger.LogError(this, player.ToString(), cardAmount.ToString());
        cardAmount--;
    }

    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Logger.LogError(this, "Awake", "Instance already exists");
    }
}
