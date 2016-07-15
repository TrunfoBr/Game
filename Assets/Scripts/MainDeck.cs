using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MainDeck : NetworkBehaviour {

    public static MainDeck Instance;
    public int cardAmount = 0;
    public bool deckReady = false;

    void Update() {
        if (stillHasCards() && deckReady) {
            
        }
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
