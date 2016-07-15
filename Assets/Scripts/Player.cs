using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {
    
    public static int numberOfPlayers = 0;
    public int playerId;

    public override void OnStartLocalPlayer() {
        CmdStart();
    }

    [Command]
    public void CmdStart() {
        playerId = numberOfPlayers++;
        gameObject.name = "Player" + playerId.ToString();
    }

    void Update() {
        if (!isLocalPlayer)
            return;

        /*var deck = MainDeck.Instance;
        if (deck.stillHasCards()) {
            deck.GiveCardTo(gameObject);
        }*/
    }
}
