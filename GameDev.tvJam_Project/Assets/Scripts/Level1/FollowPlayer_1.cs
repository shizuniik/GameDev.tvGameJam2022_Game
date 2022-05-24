using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer_1 : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }


}
