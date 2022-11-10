using TMPro;
using UnityEngine;

public class LooseScreen : MonoBehaviour
{
    static LooseScreen instance = null;
    public static LooseScreen Instance { get => instance; }
    public GameObject lastTryDuration;
    public GameObject gameCounter;
    private void Awake()
    {
        InstanceLooseScreen();
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        ShowText();
    }

    public void GameOver()
    {
        this.gameObject.SetActive(true);
    }

    public void ChangeDifficulty()
    {
        this.gameObject.SetActive(false);
        MainMenu.Instance.gameObject.SetActive(true);
        MainMenu.Instance.gameObject.transform.Find("DifficultyMenu").gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        GameLvl.Instance.RestartLvl();
    }

    public void ShowText()
    {
        lastTryDuration.GetComponent<TextMeshProUGUI>().text = "Продолжительность последней попытки: " + GameLvl.Instance.timeGame.ToString("0.00");

        if (PlayerPrefs.HasKey("gameCounter"))
        {
            gameCounter.GetComponent<TextMeshProUGUI>().text = "Счетчик попыток игры: " + PlayerPrefs.GetInt("gameCounter");

        }
        else
        {
            gameCounter.GetComponent<TextMeshProUGUI>().text = "Счетчик попыток игры: 0";
        }
    }

    public void InstanceLooseScreen()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }


    }
}
