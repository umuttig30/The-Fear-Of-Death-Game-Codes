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

    //Missä tietokanta majailee
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
                    //selvitetään löytyykö pinkoodi
                    while (reader.Read())
                    {
                        //Löytyi, joten otetaan lempinimi talteen
                        nickname = reader["nickname"].ToString();

                        //Nostetaan lippu merkiksi että tietokantaoperaatio onnistui.
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
        // onnistuneen kirjautumisen jälkeen siirytään pelialueelle.
        SceneManager.LoadScene("The Fear Of Death");

    }

    



}
