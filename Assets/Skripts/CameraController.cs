using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController instance = null;
    public static CameraController Instance { get => instance; }

    public float smooth = 1f;
    Transform target;

    private void Awake()
    {
        InstanceCameraControler();
    }
  

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, pos, smooth);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }


    public void InstanceCameraControler()
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
