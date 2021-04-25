using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{

    [SerializeField]
    ButtonComponent[] buttons;

    List<int> correctSolution = new List<int>{ 0, 2, 5, 8, 10 };

    [SerializeField]
    Door door;

    GameObject soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = Resources.Load<GameObject>("SoundPrefabs/SolvedSound");

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].bp = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSolution()
    {
        Debug.Log("Checkling solution!");

        bool isSolved = true;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (correctSolution.Contains(i))
            {
                isSolved = isSolved && buttons[i].isPressed;
            }
            else
            {
                isSolved = isSolved && !buttons[i].isPressed;
            }
        }

        Debug.Log(isSolved);
        if (isSolved)
        {
            FindObjectOfType<GameManager>().lockedDoorStates[door.ID] = false;
            Instantiate(soundEffect);
        }


        
    }
}
