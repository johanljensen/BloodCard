using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    Sprite cardImage;

    [TextArea]
    [SerializeField]
    string cardText;

    public Sprite GetCardImage()
    { return cardImage; }

    public string GetCardText()
    { return cardText; }
}
