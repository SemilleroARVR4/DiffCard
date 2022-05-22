using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceInfo : MonoBehaviour
{
    public string PerformanceId { get; private set; }
    public double AvgCouples { get; private set; }
    public double FinalTime { get; private set; }
    public int Score { get; private set; }
    public int PerceptionDifficulty { get; private set; }
    public string IdMatch { get; private set; }

    public void ResetInfo()
    {
        PerformanceId = "";
        AvgCouples = 0;
        FinalTime = 0;
        Score = 0;
        PerceptionDifficulty = 0;
        IdMatch = "";
    }


    public void SetId(string id)
    {
        PerformanceId = id;
    }
    public void SetAvgCouples(double avgcouples)
    {
        AvgCouples = avgcouples;
    }
    public void SetFinalTime(double finaltime)
    {
        FinalTime = finaltime;
    }
    public void SetScore(int score)
    {
        Score = score;
    }
    public void SetPerceptionDf(int perceptiondf)
    {
        PerceptionDifficulty = perceptiondf;
    }
    public void SetIdMatch(string idmatch)
    {
        IdMatch = idmatch;
    }


}
