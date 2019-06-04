using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBirdsManager : MonoBehaviour
{

    private CandyManager candyManager;

    private string BIRDS_TAG = "unlocked-birds";

    private bool[] initialArray = new bool[] {
        true, false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false, false
    };
    private bool[] birds;

    void Start()
    {
        candyManager = GetComponent<CandyManager>();

        birds = PlayerPrefsX.GetBoolArray(BIRDS_TAG);
        if (birds.Length == 0)
        {
            PlayerPrefsX.SetBoolArray(BIRDS_TAG, initialArray);
            birds = initialArray;
        }
    }

    public bool IsUnlocked(int index)
    {
        return birds[index];
    }

    public void UnlockBird(int index, int value)
    {
        birds[index] = true;
        PlayerPrefsX.SetBoolArray(BIRDS_TAG, birds);

        candyManager.BuyBird(value);
    }
    
}
