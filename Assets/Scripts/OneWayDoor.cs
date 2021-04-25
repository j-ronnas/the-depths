using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().onInteraction += UnlockOtherSide;
    }

    // Update is called once per frame
    void UnlockOtherSide()
    {
        FindObjectOfType<GameManager>().lockedDoorStates[1] = false;
    }
}
