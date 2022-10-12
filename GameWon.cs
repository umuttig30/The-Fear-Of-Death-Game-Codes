using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{

    public GameObject Gamewon;   
    private void OnTriggerEnter(Collider other)
    {
        LevelComplete();
     }
    public void LevelComplete()
    {
        Gamewon.SetActive(true);
    }
}
