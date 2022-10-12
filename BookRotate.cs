using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRotate : MonoBehaviour
{
    [SerializeField] private int rotatespeed;
    [SerializeField] private Vector3 rotateaxis;

    private void Update()
    {
        transform.Rotate(rotatespeed * Time.deltaTime * rotateaxis, Space.World);
    }
}
