using UnityEngine;
public class MainMenu : MonoBehaviour
{
    static MainMenu instance = null;
    public static MainMenu Instance { get => instance; }

    private void Awake()
    {
        InstanceMainMenu();
    }

    public void InstanceMainMenu()
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

    public void PlayGame()
    {

        this.gameObject.SetActive(false);
        GameLvl.Instance.RestartLvl();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Difficulty1()
    {
        this.gameObject.SetActive(false);
        GameController.Instance.difficultyNumber = 1;
    }

    public void Difficulty2()
    {
        this.gameObject.SetActive(false);
        GameController.Instance.difficultyNumber = 2;
    }

    public void Difficulty3()
    {
        this.gameObject.SetActive(false);
        GameController.Instance.difficultyNumber = 3;
    }
}
