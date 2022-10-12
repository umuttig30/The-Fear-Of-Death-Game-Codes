using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using System.Data;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    //GUIlta saatu pinkoodi
    [SerializeField] private TMP_InputField pincode;

    //GUIn virhekooditeksti
    [SerializeField] private TMP_Text errorText;

    //Miss� tietokanta majailee
    private string dbConnectionString;

    public static string nickname = "";

    public bool LoginOK { get; set; }

    private void Awake()
    {
        dbConnectionString = "URI=file:tietoVarasto.db";
        LoginOK = false;
    }

    public void LogIn()
    {
        print($"pincode:{pincode.text}");
        using (var connection = new SqliteConnection(dbConnectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //SQL-lause, jolla haetaan pinkoodi
                command.CommandText = $"select * from Login where pincode = '{pincode.text}' ";
                print(command.CommandText);
                //suoritetaan haku
                using (IDataReader reader = command.ExecuteReader())
                {
                    //selvitet��n l�ytyyk� pinkoodi
                    while (reader.Read())
                    {
                        //L�ytyi, joten otetaan lempinimi talteen
                        nickname = reader["nickname"].ToString();

                        //Nostetaan lippu merkiksi ett� tietokantaoperaatio onnistui.
                        LoginOK = true;
                    }
                    // suljetaan haku
                    reader.Close();

                }

            }
            //Suljetaan tietokantayhteys
            connection.Close();
        }
       

        if (!LoginOK)
        {
            errorText.gameObject.SetActive(true);
            return;
        }
        errorText.gameObject.SetActive(false);
        // onnistuneen kirjautumisen j�lkeen siiryt��n pelialueelle.
        SceneManager.LoadScene("The Fear Of Death");

    }

    



}
