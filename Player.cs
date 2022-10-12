using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerDataFromJSON();
    }

   private void LoadPlayerDataFromJSON()
    {
        PlayerData playerData = DataManager.LoadPlayerDataFromJSON();

        Vector3 position = new Vector3()
        {
            x = playerData.position[0],
            y = playerData.position[1],
            z = playerData.position[2]
        };

        // Sijoittaa pelihahmon JSON tiedostossa olevien x,y,z arvojen kertomaan paikkaan
        transform.position = position;
    }


    // Tallennetaan pelihahmon tilatiedot JSON tiedostoksi
    public void SavePlayerDataToJSON()
    {
        DataManager.SavePlayerDataToJSON(this);
    }

}
