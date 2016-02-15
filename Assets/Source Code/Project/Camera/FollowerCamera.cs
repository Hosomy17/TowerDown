using UnityEngine;
using System.Collections;

public class FollowerCamera : MonoBehaviour
{
    public GameObject target;
    public bool isLockX;
    public bool isLockY;
    public bool isLockZ;

    private Vector3 newPos;
    void Update()
    {
        newPos = target.transform.position;
        
        if(isLockX)
            newPos.x = transform.position.x;

        if(isLockY)
            newPos.y = transform.position.y;

        if(isLockZ)
            newPos.z = transform.position.z;

        transform.position = newPos;
    }
}
