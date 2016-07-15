using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public Text cardNameText;
    public Text[] attributeText;

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
    
    static public Card Max(Card a, Card b, CardAttributes att) {
        Debug.Log("Comparing attributes " + a.GetAttribute(att) + " with " + b.GetAttribute(att));
        switch(att) {
            case (CardAttributes.At1):
                return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
            case (CardAttributes.At2):
                return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
            case (CardAttributes.At3):
                return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
            case (CardAttributes.At4):
                return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
            case (CardAttributes.At5):
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
