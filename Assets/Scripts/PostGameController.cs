using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostGameController : MonoBehaviour
{
    [SerializeField]
    GameObject _EncuestaScene;
    [SerializeField]
    GameObject _ContinuarScene;
    [SerializeField]
    Encuesta _Encuesta;
    public Main main;

    private double tiempoSesion;
    private void Start()
    {
        main = FindObjectOfType<Main>();
        tiempoSesion = main.SessionInfo.Totaltime;
    }

    private void Update()
    {
        tiempoSesion += Time.deltaTime;
        main.SessionInfo.SetTotalTime(tiempoSesion);
    }

    public void EjecutarBtnEncuesta(string a)
    {
        switch (a)
        {
            case "1":
                main.PerformanceInfo.SetPerceptionDf(1);
                _Encuesta.RegistrarValorEncuesta(1);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "2":
                main.PerformanceInfo.SetPerceptionDf(2);
                _Encuesta.RegistrarValorEncuesta(2);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "3":
                main.PerformanceInfo.SetPerceptionDf(3);
                _Encuesta.RegistrarValorEncuesta(3);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "4":
                main.PerformanceInfo.SetPerceptionDf(4);
                _Encuesta.RegistrarValorEncuesta(4);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
            case "5":
                main.PerformanceInfo.SetPerceptionDf(5);
                _Encuesta.RegistrarValorEncuesta(5);
                _EncuestaScene.SetActive(false);
                _ContinuarScene.SetActive(true);
                break;
        }
    }

    public void EjecutarBtnSeguirJugando(string a)
    {

        int numbergames = main.SessionInfo.NumberGames + 1;

        //Match Game
        int arraySize = main.MatchGameInfo.Arraysize;
        int timelimit = main.MatchGameInfo.Timelimit;
        string theme = main.MatchGameInfo.Theme;
        string Fsesion = main.SessionInfo.SessionId;

        switch (a)
        {
            case "Seguir":
                main.SessionInfo.SetNumberGames(numbergames);
                StartCoroutine(main.web.RegisterMatchGame(arraySize, timelimit, theme, Fsesion));

                //SceneManager.LoadScene("Menu_Game");

                break;

            case "Salir":
                main.SessionInfo.SetNumberGames(numbergames);

                double totaltime = Math.Round(main.SessionInfo.Totaltime, 2);
                numbergames = main.SessionInfo.NumberGames;
                string idSession = main.SessionInfo.SessionId;

                StartCoroutine(main.web.ModifyDataSession(idSession, totaltime, numbergames));
                StartCoroutine(main.web.RegisterMatchGame(arraySize, timelimit, theme, Fsesion));


                //Performances
                /*double avgPareja = Math.Round(main.PerformanceInfo.AvgCouples, 2);
                double finaltime = Math.Round(main.PerformanceInfo.FinalTime, 2);
                int score = main.PerformanceInfo.Score;
                int perception = main.PerformanceInfo.PerceptionDifficulty;
                string FMatch = main.MatchGameInfo.MatchGameId;
                Debug.Log(FMatch);*/

                //StartCoroutine(WaitSecond(avgPareja, finaltime, score, perception, FMatch));
                //SceneManager.LoadScene("Inicial_Registro");
                break;
        }
    }

    private void OnApplicationQuit()
    {
        double totaltime = Math.Round(main.SessionInfo.Totaltime,2);
        int numbergames = main.SessionInfo.NumberGames;
        string idSession = main.SessionInfo.SessionId;

        StartCoroutine(main.web.ModifyDataSession(idSession, totaltime, numbergames));
    }


}
