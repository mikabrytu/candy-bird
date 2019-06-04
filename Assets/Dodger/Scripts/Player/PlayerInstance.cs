using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    
    [SerializeField]
    private Material[] bodies;
    [SerializeField]
    private Material[] faces;
    [SerializeField]
    public Renderer body;
    [SerializeField]
    public Renderer face;

    private int current = 0;
    private PlayerBirdsManager birdManager;
    private CandyManager candyManager;
    private UIManager uiManager;
    private int[] prices = new int[] { 10, 20, 30, 40, 50, 60 };
    private int price;

    void Start()
    {
        birdManager = GameObject.Find("Game Manager").GetComponent<PlayerBirdsManager>();
        candyManager = GameObject.Find("Game Manager").GetComponent<CandyManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        body.sharedMaterial = bodies[current];
        face.sharedMaterial = faces[current];
    }

    public void NextBird()
    {
        current++;

        if (current == bodies.Length)
            current = 0;

        SetPrice();

        body.sharedMaterial = bodies[current];
        face.sharedMaterial = faces[current];

        CheckIfIsLocked();
    }

    public void PreviousBird()
    {
        current--;

        if (current < 0)
            current = bodies.Length - 1;

        SetPrice();

        body.sharedMaterial = bodies[current];
        face.sharedMaterial = faces[current];

        CheckIfIsLocked();
    }

    public void Buy()
    {
        // TODO: Apply the real bird price
        if (price <= candyManager.GetCandyValue())
        {
            birdManager.UnlockBird(current, price);
            uiManager.ShowCandyCount(candyManager.GetCandyValue().ToString());
            uiManager.UnlockPlay();
            uiManager.HideBuyGroup();
        }
    }

    private void CheckIfIsLocked()
    {
        if (!birdManager.IsUnlocked(current))
        {
            uiManager.LockPlay();
            uiManager.ShowBuyGroup(price);
        } else
        {
            uiManager.UnlockPlay();
            uiManager.HideBuyGroup();
        }
    }

    private void SetPrice()
    {
        if (current < 3)
            price = prices[0];
        else if (current < 6)
            price = prices[1];
        else if (current < 9)
            price = prices[2];
        else if (current < 12)
            price = prices[3];
        else if (current < 15)
            price = prices[4];
        else if (current < 18)
            price = prices[5];
    }

}
