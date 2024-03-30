using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{
    private static CardPreview Instance;

    public static CardPreview GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<CardPreview>(includeInactive: true);
        }
        
        return Instance;
    }

    [SerializeField]
    Image previewImage;

    [SerializeField]
    TextMeshProUGUI previewText;

    private void Start()
    {
        ClearPreview();
    }

    public void SetCardPreview(Card cardToPreview)
    {
        if (cardToPreview != null)
        {
            gameObject.SetActive(true);
            previewImage.sprite = cardToPreview.GetCardImage();
            previewText.text = cardToPreview.GetCardText();
        }
    }

    public void ClearPreview()
    {
        gameObject.SetActive(false);
    }
}
