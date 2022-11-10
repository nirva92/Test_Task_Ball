using System.Collections.Generic;
using UnityEngine;

public class GameLvl : MonoBehaviour
{
    static GameLvl instance = null;
    public static GameLvl Instance { get => instance; }

    public PrefabManager prefabManager;
    public List<GameObject> wallList = new List<GameObject>();
    public float timeAccelerationBall = 15;
    public float timeGame = 0;
    public bool timerActive = false;
    public int timeLvl = 0;
    public bool isPlaying = false;


    GameObject newBall;
    GameObject newWall;

    private void Awake()
    {
        InstanceGameLvl();
    }

    void Start()
    {
        SpawnBall();
        SpawnWall();
    }

    void Update()
    {
        DestroyWall();
        SpawnNewWall();
        ActiveTimer();
        timeAccelerationBall -= Time.deltaTime;
    }

    public void SpawnBall()
    {
        newBall = Instantiate(prefabManager.prefabBall);
        newBall.transform.position = newBall.transform.position + new Vector3(0, 5, 0);
        CameraController.Instance.SetTarget(newBall.transform.GetComponent<Ball>().objectCamera);
        timerActive = true;
    }

    public void SpawnWall()
    {
        for (int i = 0; i < 4; i++)
        {
            newWall = Instantiate(prefabManager.prefabWall);
            int y = Random.Range(-1, 6);
            Vector3 distanceWall = new Vector3(10 * i + 10, y, 0);
            newWall.transform.position = newWall.transform.position + distanceWall;
            wallList.Add(newWall);
        }
    }

    public void SpawnNewWall()
    {
        if (wallList.Count <= 3)
        {
            GameObject newWall = Instantiate(prefabManager.prefabWall);
            float y = Random.Range(-2.5f, 6);
            Vector3 distanceWall = new Vector3(wallList[wallList.Count - 1].transform.position.x + 10, y, 0);
            newWall.transform.position = newWall.transform.position + distanceWall;
            wallList.Add(newWall);
        }
    }
    public void InstanceGameLvl()
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


    public void DestroyWall()
    {
        for (int i = 0; i < wallList.Count; i++)
        {
            if (newBall.transform.position.x - wallList[i].transform.position.x >= 15)
            {
                Destroy(wallList[i]);
                wallList.RemoveAt(i);
                i--;
            }
        }
    }

    public void RestartLvl()
    {
        DestroyWallRestart();
        SpawnBall();
        SpawnWall();
        timeGame = 0;
        isPlaying = true;
    }

    public void DestroyWallRestart()
    {
        Destroy(newBall);
        for (int i = 0; i < wallList.Count; i++)
        {
            Destroy(wallList[i]);
        }
        wallList.Clear();
    }

    public void ActiveTimer()
    {
        if (timerActive == true)
        {
            timeGame += Time.deltaTime;
        }
    }


}
