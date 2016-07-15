using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {
    
    public static int numberOfPlayers = 0;

    [SyncVar]
    public int playerId;

    void Awake() {
        playerId = numberOfPlayers++;
        gameObject.name = "Player" + playerId.ToString();
    }

    void Update() {
        if (!isLocalPlayer)
            return;

        var deck = MainDeck.Instance;
        if (deck.stillHasCards()) {
            deck.GiveCardTo(gameObject);
        }
    }
}
