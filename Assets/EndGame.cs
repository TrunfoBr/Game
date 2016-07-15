using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public static EndGame Instance;

    private int numberOfAlivePlayers = 0;
    private List<bool> alivePlayers = new List<bool>();
    public List<GameObject> players;

    public void NotifyDeath() {
        for (int i=0; i<players.Count; i++) {
            if(players[i].GetComponent<SinglePlayer>().my_deck.Count == 0 && alivePlayers[i] == true) {
                alivePlayers[i] = false;
                numberOfAlivePlayers--;
            }
        }
        if (numberOfAlivePlayers == 1) {
            FinishGame();
        }
    }

    void Awake() {
        if (Instance == null)
            Instance = this;
    }

    void Start() {
        foreach (GameObject player in players) {
            alivePlayers.Add(true);
            numberOfAlivePlayers++;
        }
    }

    public void FinishGame() {
        Debug.LogError("We have a victor");
        SceneManager.LoadScene("mainMenu");
    }
}
