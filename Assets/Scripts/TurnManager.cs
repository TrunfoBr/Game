using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TurnManager : NetworkBehaviour {

    public static TurnManager Instance { get; private set; }
    public int currentPlayer { get; private set; }

    private int playerAmount = 0;

    public void PassTurn() {
        if (++currentPlayer == playerAmount)
            currentPlayer = 0;
    }

    public void RegisterPlayer() {
        playerAmount++;
    }
    
    public override void OnStartServer() {
        currentPlayer = 0;
    }

    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Logger.LogError(this, "Awake", "Instance already exists");
    }
}
