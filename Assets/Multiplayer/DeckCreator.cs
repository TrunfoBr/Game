using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DeckCreator : NetworkBehaviour {

    public GameObject deck;

    public override void OnStartServer()
    {
        deck = Instantiate(deck);
        NetworkServer.Spawn(deck);

        var cards = CardList.Instance;
        for (int i = 0; i < cards.CardAmount; i++)
        {
            deck.GetComponent<MainDeck>().cardAmount++;
            var card = cards.GetCard(i);
            card.SetActive(true);
            NetworkServer.Spawn(card);
            //card.transform.parent = deck.transform;
        }
        deck.GetComponent<MainDeck>().deckReady = true;
    }
}
