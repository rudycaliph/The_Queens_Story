using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

    private Transform target;
    private float trackSpeed = 14;

    public void setTarget(Transform t)
    {
        target = t;
    }

    void LateUpdate()
    {
        if (target)
        {
            float x = cameraFollow(transform.position.x, target.position.x, trackSpeed);
            float y = cameraFollow(transform.position.y, target.position.y, trackSpeed);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    private float cameraFollow(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n: target;
        }
    }
}
