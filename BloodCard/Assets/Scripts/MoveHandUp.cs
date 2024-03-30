using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandUp : MonoBehaviour
{
    [SerializeField]
    Transform cardHolder;

    [SerializeField]
    float hiddenYpos;

    [SerializeField]
    float focusedYpos;

    bool checkingForMouseExit = false;

    private void Start()
    {
        cardHolder.localPosition = new Vector3(transform.localPosition.x, hiddenYpos, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, hiddenYpos, transform.localPosition.z);
    }

    private void OnMouseEnter()
    {
        cardHolder.localPosition = new Vector3(transform.localPosition.x, focusedYpos, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, focusedYpos, transform.localPosition.z);

        if (!checkingForMouseExit)
        {
            StartCoroutine(WaitForMouseExit());
        }
    }

    private IEnumerator WaitForMouseExit()
    {
        checkingForMouseExit = true;

        while(Input.mousePosition.y < Screen.height * 0.3)
        {
            yield return null;
        }

        cardHolder.localPosition = new Vector3(transform.localPosition.x, hiddenYpos, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, hiddenYpos, transform.localPosition.z);
    }
}
