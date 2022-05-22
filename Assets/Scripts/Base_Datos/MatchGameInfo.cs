using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameInfo : MonoBehaviour
{
    public string MatchGameId { get; private set; }
    public int Arraysize { get; private set; }
    public int Timelimit { get; private set; }
    public string Theme { get; private set; }
    public string Idsession { get; private set; }


    public void ResetInfo() 
    {
        MatchGameId = "";
        Arraysize = 0;
        Timelimit = 0;
        Theme = "";
        Idsession = "";
    }


    public void SetIdMatch(string id)
    {
        MatchGameId = id;
    }
    public void SetArraySize(int arraysize)
    {
        Arraysize = arraysize;
    }
    public void SetTimeLimit(int timelimit)
    {
        Timelimit = timelimit;
    }
    public void SetTheme(string theme)
    {
        Theme = theme;
    }
    public void SetIdSession(string idsession)
    {
        Idsession = idsession;
    }
}
