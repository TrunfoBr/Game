using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MainDeck : NetworkBehaviour {

    public static MainDeck Instance;

    public override void OnStartServer() {
        var cards = CardList.Instance;
        for (int i = 0; i < cards.CardAmount; i++) {
            var card = cards.GetCard(i);
            card.transform.parent = transform;
            NetworkServer.Spawn(card);
        }
    }

    public void GiveCardTo(GameObject player) {

    }

    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Logger.LogError(this, "Awake", "Instance already exists");
    }
}
