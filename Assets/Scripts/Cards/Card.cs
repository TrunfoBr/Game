﻿using UnityEngine;
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
    
    public Card Max(Card a, Card b, CardAttributes att) {
        return a.GetAttribute(att) > b.GetAttribute(att) ? a : b;
    }

    void Start() {
        cardNameText.text = name;
    }

    private bool IsAttributeValid(CardAttributes att) {
        return (int)att >= 0 && (int)att < 5;
    }
}
