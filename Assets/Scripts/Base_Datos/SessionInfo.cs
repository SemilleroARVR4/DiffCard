using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionInfo : MonoBehaviour
{
    public string SessionId { get; private set;}
    public string SessionDate { get; private set;}
    public double Totaltime { get; private set; }
    public int NumberGames { get; private set; }
    public string IdUser { get; private set;}


    public void ResetInfo() 
    {
        SessionId = "";
        SessionDate = "";
        Totaltime = 0f;
        NumberGames = 0;
    }


    public void SetID(string id)
    {
        SessionId = id;
    }

    public void SetDate(string sessiondate)
    {
        SessionDate = sessiondate;
    }

    public void SetTotalTime(double totalTime)
    {
        Totaltime = totalTime;
    }

    public void SetNumberGames(int numbergames)
    {
        NumberGames = numbergames;
    }
    public void SetIdUser(string iduser)
    {
        IdUser = iduser;
    }

}
