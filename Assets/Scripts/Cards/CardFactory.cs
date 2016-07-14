using UnityEngine;

public class CardFactory : MonoBehaviour {

    public GameObject cardTemplate;
    public GameObject cardList;

    void Start() {
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
            GenerateCard(i.ToString());
    }
    
    private void GenerateCard(string cardName) {
        var newCard = Instantiate(cardTemplate);
        newCard.name = cardName;
        CardList.Instance.AddCard(newCard);
    }
}
