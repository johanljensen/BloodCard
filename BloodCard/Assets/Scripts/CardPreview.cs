using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{
    [SerializeField]
    Image previewImage;

    [SerializeField]
    Text previewText;

    public void SetCardPreview(Sprite cardSprite, string cardText)
    {
        previewImage.sprite = cardSprite;
        previewText.text = cardText;
    }
}
