using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    private double tiempoSesion;
    public Main main;

    private void Start()
    {
        main = FindObjectOfType<Main>();
        Time.timeScale = 1;
        tiempoSesion = main.SessionInfo.Totaltime;
        ModificarSession();
    }
    public void ActivarEscenaPostJuego() 
    {
        SceneManager.LoadScene("PostGame");
    }


    private void Update()
    {
        tiempoSesion += Time.deltaTime;
        main.SessionInfo.SetTotalTime(tiempoSesion);
    }

    private void OnApplicationPause()
    {
        double totaltime = Math.Round(main.SessionInfo.Totaltime, 2);
        int numbergames = main.SessionInfo.NumberGames;
        string idSession = main.SessionInfo.SessionId;

        StartCoroutine(main.web.ModifyDataSession(idSession, totaltime, numbergames));
    }

    void ModificarSession() 
    {
        double totaltime = Math.Round(main.SessionInfo.Totaltime, 2);
        int numbergames = main.SessionInfo.NumberGames;
        string idSession = main.SessionInfo.SessionId;

        StartCoroutine(main.web.ModifyDataSession(idSession, totaltime, numbergames));
    }

}
