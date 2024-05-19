using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Camera position should follow the players position
    [SerializeField] GameObject objectToFollow;

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + new Vector3(0,0,-10);
    }
}
