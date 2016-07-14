﻿using UnityEngine;

public class CardFactory : MonoBehaviour {

    public GameObject cardTemplate;
    public GameObject cardList;

    void Awake() {
        if (ShouldGenerateCardList()) {
            CreateCardList();
            GenerateCards();
        }
    }

    private bool ShouldGenerateCardList() {
        return CardList.Instance == null;
    }

    private void CreateCardList() {
        cardList = Instantiate(cardList);
        DontDestroyOnLoad(cardList);
    }

    private void GenerateCards() {
        for (int i = 0; i < 10; ++i)
            GenerateCard("Fulano de tal #" + i.ToString() + " - C++");
    }

    private void GenerateCard(string cardName) {
        var newCard = Instantiate(cardTemplate);
        newCard.name = cardName;
        var cardScript = newCard.GetComponent<Card>();
        for (int i = 0; i < 5; ++i)
            cardScript.SetAttribute((CardAttributes)i, Random.Range(1, 11));
        CardList.Instance.AddCard(newCard);
    }
}
