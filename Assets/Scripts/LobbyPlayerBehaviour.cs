using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LobbyPlayerBehaviour : NetworkLobbyPlayer {

    public override void OnClientEnterLobby() {
        GetComponent<NetworkLobbyPlayer>().readyToBegin = true;
    }

}
