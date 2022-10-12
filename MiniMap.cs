using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float height;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y += height;
        transform.position = newPosition;
    }
}
