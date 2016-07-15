using UnityEngine;
using System.Collections;

public class CardFactory : MonoBehaviour {

    public string dbUrl;
    public GameObject cardTemplate;
    public GameObject cardList;

    public bool isDone { get; private set; }
    public float progress { get; private set; }

    void Awake() {
        isDone = false;
        if (ShouldGenerateCardList()) {
            WWW www = new WWW(dbUrl);
            StartCoroutine(WaitForRequest(www));
        }
    }

    private bool ShouldGenerateCardList() {
        return CardList.Instance == null;
    }

    IEnumerator WaitForRequest(WWW www) {
        while (!www.isDone) {
            progress = www.progress * 100f;
            yield return null;
        }

        if (www.error == null) {
            Debug.Log("WWW OK!");
            CreateCardList();
            GenerateCards(www);
            isDone = true;
        }
        else {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    private void CreateCardList() {
        cardList = Instantiate(cardList);
        DontDestroyOnLoad(cardList);
    }

    private void GenerateCards(WWW www) {
        var politicianList = JsonUtility.FromJson<PoliticianArray>(www.text);
        for (int i = 0; i < politicianList.Size; ++i)
            GenerateCard(politicianList.politicians[i]);
    }

    private void GenerateCard(Politician politician) {
        var newCard = Instantiate(cardTemplate);
        newCard.name = politician.name;
        var cardScript = newCard.GetComponent<Card>();
        for (int i = 0; i < 5; ++i)
            cardScript.SetAttribute((CardAttributes)i, politician.attributes[i]);
        CardList.Instance.AddCard(newCard);
    }
}
