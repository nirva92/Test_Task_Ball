using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController instance = null;
    public static GameController Instance { get => instance; }

    public int difficultyNumber = 1;


    void Start()
    {
        InstanceGameControler();
    }


    public void InstanceGameControler()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
}
