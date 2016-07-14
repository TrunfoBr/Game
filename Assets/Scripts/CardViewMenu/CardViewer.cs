using UnityEngine;

public class CardViewer : MonoBehaviour {

    private int currentPosition = 0;
    private GameObject currentCard;

    public void ViewNextCard() {
        if (currentPosition < CardList.Instance.CardAmount - 1)
            GetCardAt(++currentPosition);
    }

    public void ViewPreviousCard() {
        if (currentPosition > 0)
            GetCardAt(--currentPosition);
    }

    void Start() {
        GetCardAt(currentPosition);
    }

    private void GetCardAt(int pos) {
        Destroy(currentCard);
        currentCard = CardList.Instance.GetCard(pos);
        currentCard.SetActive(true);
        currentCard.transform.parent = transform;
        currentCard.transform.position = currentCard.transform.parent.position;
        currentCard.name = currentCard.name.Remove(currentCard.name.Length-7, 7);
    }
}
