using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {

    public static TurnManager Instance;

    public List<GameObject> players;
    public int turn = 0;
    public bool endOfTurn = false;

    void Start() {
        players[turn].GetComponent<SinglePlayer>().turn = true;
    }

    void Update() {
        if (endOfTurn) {
            players[turn].GetComponent<SinglePlayer>().turn = false;
            endOfTurn = false;
            turn = EndOfTurn.Instance.LastWinner;
            players[turn].GetComponent<SinglePlayer>().turn = true;
        }
    }

    public void EndMyTurn() {
        endOfTurn = true;
    }

    void Awake() {
        if (Instance == null)
            Instance = this;
    }
}
