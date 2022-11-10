using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speedBall;
    public Transform objectCamera;


    void Update()
    {
        IncreaseSpeed();
        MoveBall();
        Barrier();
        ChangeSpeedBall();
    }

    public void MoveBall()
    {
        if (GameLvl.Instance.isPlaying == false)
        {
            return;
        }

        float verticalSpeed = 1;
        verticalSpeed = verticalSpeed + 0.5f * GameLvl.Instance.timeLvl;

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = this.transform.position + new Vector3(1, verticalSpeed, 0) * speedBall * Time.deltaTime;
        }

        else
        {
            this.transform.position = this.transform.position + new Vector3(1, -verticalSpeed, 0) * speedBall * Time.deltaTime;
        }

    }

    public void IncreaseSpeed()
    {
        if (GameLvl.Instance.timeAccelerationBall <= 0)
        {
            GameLvl.Instance.timeAccelerationBall = 15;
            GameLvl.Instance.timeLvl++;
        }
    }

    public void Barrier()
    {
        if (this.transform.position.y >= 6 && Input.GetKey(KeyCode.W))
        {
            Vector3 savePosition = this.transform.position;
            savePosition.y = 6;
            this.transform.position = savePosition;
        }

        if (this.transform.position.y <= -2.5f && Input.GetKey(KeyCode.W) != true)
        {
            Vector3 savePosition = this.transform.position;
            savePosition.y = -2.5f;
            this.transform.position = savePosition;
        }
    }

    public void ChangeSpeedBall()
    {
        if (GameController.Instance.difficultyNumber == 1)
        {
            GameController.Instance.difficultyNumber = 1;
            this.speedBall = 2;
        }

        if (GameController.Instance.difficultyNumber == 2)
        {
            GameController.Instance.difficultyNumber = 2;
            this.speedBall = 5;
        }
        if (GameController.Instance.difficultyNumber == 3)
        {
            GameController.Instance.difficultyNumber = 3;
            this.speedBall = 10;
        }
    }





}
