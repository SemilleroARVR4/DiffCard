using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameController : MonoBehaviour
{

    [SerializeField]
    GameObject _MenuScene;
    [SerializeField]
    private Text textTema;
    [SerializeField]
    private Text textParejas;

    private string[] temasJuego;
    private int index_T = 0;
    private int nParejas = 4;
    private int maxParejas = 8;
    private double tiempoSesion;
    public Main main;

    private void Start()
    {
        main = FindObjectOfType<Main>();
        Time.timeScale = 1;

        tiempoSesion = main.SessionInfo.Totaltime;

        textTema.text = "Frutas";
        textParejas.text = "4";
        temasJuego = new string[] {"Frutas","Animales"};    
    }

    private void Update()
    {
        tiempoSesion += Time.deltaTime;
        main.SessionInfo.SetTotalTime(Math.Round(tiempoSesion,2));
    }

    public void EjecutarBtnMenuPrincipal(string a)
    {

        switch (a)
        {
            case "TD":
                index_T ++;
                if (index_T > (temasJuego.Length-1))
                {
                    index_T = 0;
                }
                textTema.text = temasJuego[index_T];
                break;
            case "TI":
                index_T--;
                if (index_T < 0) 
                {
                    index_T = temasJuego.Length-1;
                }
                textTema.text = temasJuego[index_T];
                break;
            case "ND":
                nParejas += 2;
                if (nParejas > maxParejas)
                {
                    nParejas = 4;
                }
                textParejas.text = nParejas.ToString();
                break;
            case "NI":
                nParejas -= 2;
                if (nParejas < 4)
                {
                    nParejas = maxParejas;
                }
                textParejas.text = nParejas.ToString();
                break;
            case "Jugar":

                main.MatchGameInfo.SetTheme(temasJuego[index_T]);
                main.MatchGameInfo.SetArraySize(nParejas);

                SceneManager.LoadScene("Game");
                break;
                        
        }
    }


    private void OnApplicationQuit()
    {
        double totaltime = Math.Round(main.SessionInfo.Totaltime, 2);
        int numbergames = main.SessionInfo.NumberGames;
        string idSession = main.SessionInfo.SessionId;

        StartCoroutine(main.web.ModifyDataSession(idSession, totaltime, numbergames));
    }


}
