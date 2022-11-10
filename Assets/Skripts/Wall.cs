using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LooseScreen.Instance.GameOver();
        GameLvl.Instance.timerActive = false;
        GameLvl.Instance.isPlaying = false;

        if (PlayerPrefs.HasKey("gameCounter") == false)
        {
            PlayerPrefs.SetInt("gameCounter", 0);
        }

        int gameCount = PlayerPrefs.GetInt("gameCounter");
        gameCount += 1;
        PlayerPrefs.SetInt("gameCounter", gameCount);
    }



}
