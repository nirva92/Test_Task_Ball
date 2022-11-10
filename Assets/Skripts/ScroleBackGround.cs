using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScroleBackGround : MonoBehaviour
{
    public List<GameObject> background = new List<GameObject>();
    public float size = 23.7f;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
 
    void Update()
    {
        for (int i = 0; i < background.Count; i++)
        {
            float cameraPositionX = cameraTransform.position.x;
            Vector3 backgroundPosition = background[i].transform.position;

            if (backgroundPosition.x < cameraPositionX - size)
            {
                backgroundPosition.x += size * 2;
                background[i].transform.position = backgroundPosition;
            }
            if (backgroundPosition.x > cameraPositionX + size)
            {
                backgroundPosition.x -= size * 2;
                background[i].transform.position = backgroundPosition;
            }
        }
    }
}
