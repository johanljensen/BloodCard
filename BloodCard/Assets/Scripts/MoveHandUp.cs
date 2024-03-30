using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandUp : MonoBehaviour
{
    [SerializeField]
    float hiddenYpos;


    [SerializeField]
    float focusedYpos;

    private void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, hiddenYpos, transform.localPosition.z);
    }

    private void OnMouseEnter()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, focusedYpos, transform.localPosition.z);
    }

    private void OnMouseExit()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, hiddenYpos, transform.localPosition.z);
    }
}
