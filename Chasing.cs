using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Chasing : MonoBehaviour
{
    public Transform pelaaja;

    public float chaseDistance = 4.0f;
    public NavMeshAgent enemy; 
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, pelaaja.transform.position);

        if(chaseDistance < distance)
        {
            enemy.SetDestination(pelaaja.position);          
        }
    }

}
