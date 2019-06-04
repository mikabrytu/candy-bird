using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{

    private string CANDY_TAG = "candies";
    private int candies = 0;

    void Awake()
    {
        candies = PlayerPrefs.GetInt(CANDY_TAG, 0);
    }

    public int GetCandyValue()
    {
        return candies;
    }

    public void AddCandy()
    {
        candies++;
        PlayerPrefs.SetInt(CANDY_TAG, candies);
    }

    public void BuyBird(int value)
    {
        candies -= value;
        PlayerPrefs.SetInt(CANDY_TAG, candies);
    }
}
