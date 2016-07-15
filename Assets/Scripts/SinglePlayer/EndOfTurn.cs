using UnityEngine;

public class EndOfTurn : MonoBehaviour {

    public SinglePlayer[] players;

    public static EndOfTurn Instance { get; private set; }
    public int LastWinner { get; private set; }

    public void RequestAttributeComparison(int attribute) {
        FindWinner(attribute);
        UpdateWinner();
        EndTurn();
        Logger.Log(this, "RequestAttributeComparison", "The winner is: " + LastWinner);
    }

    void Awake() {
        if (!Instance)
            Instance = this;
        else
            Logger.LogError(this, "Awake", "Instance not null");
    }

    private void FindWinner(int attribute) {
        LastWinner = 0;
        Card winnerCard = players[LastWinner].GetComponent<SinglePlayer>().hand.GetComponent<Card>();
        for (int i = 1; i < players.GetLength(0); ++i) {
            Card currentCard = players[i].GetComponent<SinglePlayer>().hand.GetComponent<Card>();
            if (Card.Max(winnerCard, currentCard, (CardAttributes)attribute) == currentCard) {
                LastWinner = i;
                winnerCard = currentCard;
            }
        }
    }

    private void UpdateWinner() {
        var winnerScript = players[LastWinner].GetComponent<SinglePlayer>();
        // Send winner head card to bottom
        {
            var card = winnerScript.my_deck[0];
            card.SetActive(false);
            winnerScript.my_deck.RemoveAt(0);
            winnerScript.my_deck.Add(card);
        }
        // Send losers head card to bottom
        for (int i = 0; i < players.GetLength(0); ++i) {
            if (i != LastWinner) {
                var loserScript = players[i].GetComponent<SinglePlayer>();
                var loserTopCard = loserScript.my_deck[0];
                loserTopCard.SetActive(false);
                loserTopCard.transform.parent = winnerScript.transform;
                winnerScript.my_deck.Add(loserTopCard);
                loserScript.my_deck.RemoveAt(0);
            }
        }
    }

    private void EndTurn() {
        TurnManager.Instance.EndMyTurn();
    }
}
