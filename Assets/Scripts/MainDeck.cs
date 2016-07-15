using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MainDeck : NetworkBehaviour {

    public override void OnStartServer() {
        var cards = CardList.Instance;
        for (int i = 0; i < cards.CardAmount; i++) {
            var card = cards.GetCard(i);
            card.transform.parent = transform;
            NetworkServer.Spawn(card);
        }
    }

}
