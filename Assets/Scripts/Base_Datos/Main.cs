using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Web web;
    public UserInfo UserInfo;
    public SessionInfo SessionInfo;
    public MatchGameInfo MatchGameInfo;
    public PerformanceInfo PerformanceInfo;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            if (Instance != this) 
            {
                Destroy(gameObject);
            }
        }

        Instance = this;
        web = GetComponent<Web>();
        UserInfo = GetComponent<UserInfo>();
        SessionInfo = GetComponent<SessionInfo>();
        MatchGameInfo = GetComponent<MatchGameInfo>();
        PerformanceInfo = GetComponent<PerformanceInfo>();

    }

}
