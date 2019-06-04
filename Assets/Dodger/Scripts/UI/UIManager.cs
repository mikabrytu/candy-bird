using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    [SerializeField] private Image muteButton;
    [SerializeField] private Sprite mutedIcon;
    [SerializeField] private Sprite playingIcon;

    [SerializeField] private TextMeshProUGUI candyCount;

    [SerializeField] private Button playButton;

    [SerializeField] private GameObject buyGroup;
    [SerializeField] private TextMeshProUGUI priceLabel;

    void Start()
    {
        ShowCandyCount(GameObject.Find("Game Manager").GetComponent<CandyManager>().GetCandyValue().ToString());
    }

    public void SetUI(GameManager.Scene scene)
    {
        switch (scene)
        {
            case GameManager.Scene.Menu:
                menuCanvas.SetActive(true);
                gameCanvas.SetActive(false);
                gameOverCanvas.SetActive(false);
                break;
            case GameManager.Scene.Game:
                menuCanvas.SetActive(false);
                gameCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                break;
            case GameManager.Scene.GameOver:
                menuCanvas.SetActive(false);
                gameCanvas.SetActive(false);
                gameOverCanvas.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ShowCandyCount(string value)
    {
        candyCount.text = value;
    }

    public void LockPlay()
    {
        playButton.interactable = false;
    }

    public void UnlockPlay()
    {
        playButton.interactable = true;
    }

    public void ShowBuyGroup(int value)
    {
        priceLabel.text = value.ToString();
        buyGroup.SetActive(true);
    }

    public void HideBuyGroup()
    {
        buyGroup.SetActive(false);
    }

    public void ToggleMuteIcon()
    {
        if (GameObject.Find("Audio Manager").GetComponent<AudioManager>().IsMuted())
            muteButton.sprite = mutedIcon;
        else
            muteButton.sprite = playingIcon;
    }

}
