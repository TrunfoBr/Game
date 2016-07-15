using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {
    void Update() {
        if (!isLocalPlayer)
            return;

        MainDeck.Instance.GiveCardTo(gameObject);
    }
}
