using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public Text cardNameText;
    public Text[] attributeText;

    [SerializeField]
    private float[] attributes = new float[5];

    public float GetAttribute(CardAttributes att) {
        if (IsAttributeValid(att))
           return attributes[(int)att];
        Logger.LogError(this, "GetAttribute", "Invalid attribute: " + (int)att);
        return 0;
    }

    public void SetAttribute(CardAttributes att, float value) {
        if (IsAttributeValid(att)) {
            attributes[(int)att] = value;
            attributeText[(int)att].text = value.ToString() + "  ";
        }
        else
            Logger.LogError(this, "GetAttribute", "Invalid attribute: " + (int)att);
    }
    
    static public Card Wins(Card a, Card b, CardAttributes att) {
        Debug.Log("[Card]Max:Comparing attributes " + a.GetAttribute(att) + " with " + b.GetAttribute(att));
        switch (att) {
            case (CardAttributes.PercentualDeFaltas):
                return a.GetAttribute(att) < b.GetAttribute(att) ? a : b;
            case (CardAttributes.MediaDeFaltas):
                return a.GetAttribute(att) < b.GetAttribute(att) ? a : b;
            case (CardAttributes.EvolucaoPatrimonial):
                return a.GetAttribute(att) < b.GetAttribute(att) ? a : b;
            case (CardAttributes.EmendasAprovadas):
                return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
            case (CardAttributes.MediaDeEmendas):
                return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
            default:
                return a;
        }
    }

    void Start() {
        cardNameText.text = name;
    }

    private bool IsAttributeValid(CardAttributes att) {
        return (int)att >= 0 && (int)att < 5;
    }
}
