using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    List<Sprite> introductionSprites;

    [SerializeField]
    Image screenimage;

    int imageCount = 0;

    private void Awake()
    {
        AdvanceIntroduction();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            AdvanceIntroduction();
        }
    }

    private void AdvanceIntroduction()
    {
        if(imageCount >= introductionSprites.Count)
        {
            SceneManager.LoadScene("CardGameScene");
            return;
        }

        screenimage.sprite = introductionSprites[imageCount];
        imageCount++;
    }
}
