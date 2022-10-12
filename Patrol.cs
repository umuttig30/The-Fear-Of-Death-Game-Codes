using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    [SerializeField] private float distance;

    private int waypointIndex;
    private float dist;

    public Transform player;
    private Vector3 movement;
    public float distancee = 20.0f;

    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void Update()
    {
        float chasedistance = Vector3.Distance(transform.position, player.transform.position);

        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(dist < distance)
        {
            IncreaseIndex();
        }

        Patroll();

        if (distancee > chasedistance)
        {
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;         
        }
    }
      
    void Patroll()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Vector3 debugVector = new Vector3(waypoints[waypointIndex].position.x, transform.position.y, waypoints[waypointIndex].position.z);
        transform.LookAt(debugVector);
        
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
