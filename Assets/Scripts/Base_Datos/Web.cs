using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Web : MonoBehaviour
{
    public string message = "";

    IEnumerator GetUsers()
    {
        string uri = "http://porose-poisons.000webhostapp.com/sqlconnect/GetUser.php";
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://porose-poisons.000webhostapp.com/sqlconnect/GetUser.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public IEnumerator Login(string username, string nick)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username.ToLower());
        form.AddField("loginNick", nick.ToLower());

        using (UnityWebRequest www = UnityWebRequest.Post("http://porose-poisons.000webhostapp.com/sqlconnect/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.UserInfo.SetCredentials(username, nick);
                Main.Instance.UserInfo.SetID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exists"))
                {
                    Debug.Log("Try Again");
                    message = "Intenta de nuevo";
                }
                else
                {
                    //If we logged in correctly
                    Main.Instance.SessionInfo.SetIdUser(Main.Instance.UserInfo.UserId);

                    string dateSS = Main.Instance.SessionInfo.SessionDate;
                    double totaltime = Main.Instance.SessionInfo.Totaltime;
                    int numbergames = Main.Instance.SessionInfo.NumberGames;
                    string fUser = Main.Instance.UserInfo.UserId.ToString();

                    StartCoroutine(Main.Instance.web.RegisterSession(dateSS, totaltime, numbergames, fUser));

                    message = "";
                    SceneManager.LoadScene("Menu_Game");
                }
            }
        }
    }

    public IEnumerator RegisterUser(string username, string nick, string birthDate,string gender)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username.ToLower());
        form.AddField("loginNick", nick.ToLower());
        form.AddField("loginBirthDate", Int16.Parse(birthDate));
        form.AddField("loginGender", gender);

        using (UnityWebRequest www = UnityWebRequest.Post("http://porose-poisons.000webhostapp.com/sqlconnect/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                message = "Error, intenta de nuevo";
            }
            else
            {
                if (www.downloadHandler.text == "Username is already taken")
                {
                    message = "Ya existe este usuario";
                } else if (www.downloadHandler.text == "Creating user...New record created successfully") 
                {
                    message = "Usuario creado";
                }
                Debug.Log(www.downloadHandler.text);
                
            }
        }
    }

    public IEnumerator RegisterSession(string dateSession, double totalTime, int numberGames, string FUser)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginDate", dateSession);
        form.AddField("loginTotalTime", totalTime.ToString());
        form.AddField("loginNG", numberGames.ToString());
        form.AddField("loginFUser", FUser);

        using (UnityWebRequest www = UnityWebRequest.Post("http://porose-poisons.000webhostapp.com/sqlconnect/RegisterSession.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.SessionInfo.SetID(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator RegisterMatchGame(int arraysize, int timelimit,string theme, string FSession, double avgPareja, double finaltime, int score, int perception)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginArraySize", arraysize);
        form.AddField("loginTimeLimit", timelimit);
        form.AddField("loginTheme", theme);
        form.AddField("loginFSession", FSession);


        using (UnityWebRequest www = UnityWebRequest.Post("http://porose-poisons.000webhostapp.com/sqlconnect/RegisterMatchGame.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string mj = www.downloadHandler.text;
                Debug.Log(mj);
                Main.Instance.MatchGameInfo.SetIdMatch(mj.ToString());

                /*//Intento
                double avgPareja = Math.Round(Main.Instance.PerformanceInfo.AvgCouples, 2);
                double finaltime = Math.Round(Main.Instance.PerformanceInfo.FinalTime, 2);
                int score = Main.Instance.PerformanceInfo.Score;
                int perception = Main.Instance.PerformanceInfo.PerceptionDifficulty;*/
                string FMatch = Main.Instance.MatchGameInfo.MatchGameId;

                StartCoroutine(Main.Instance.web.RegisterPerformance(avgPareja, finaltime, score, perception, FMatch));
                Main.Instance.MatchGameInfo.SetIdMatch("");
                mj = "";
                
            }
        }
    }

    public IEnumerator RegisterPerformance(double avgCouples, double finaltime, int score, int perception, string idMatch)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginAvgCouples", avgCouples.ToString());
        form.AddField("loginFinalTime", finaltime.ToString());
        form.AddField("loginScore", score);
        form.AddField("loginPerception", perception);
        Debug.Log(idMatch);
        form.AddField("loginFMatch", idMatch);

        using (UnityWebRequest www = UnityWebRequest.Post("http://porose-poisons.000webhostapp.com/sqlconnect/RegisterPerformance.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator ModifyDataSession(string idSession, double totalTime, int numberGames)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginIdSession", idSession);
        form.AddField("loginTotalTime", totalTime.ToString());
        form.AddField("loginNG", numberGames.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://porose-poisons.000webhostapp.com/sqlconnect/ModifyDataSession.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);            
            }
        }
    }
}
