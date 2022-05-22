using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string UserId { get; private set; }
    public string UserName { get; private set; }
    public string Nick { get; private set; }
    public string Birhdate { get; private set; }
    public string Gender { get; private set; }


    public void ResetInfo()
    {
        UserId = "";
        UserName = "";
        Nick = "";
        Birhdate = "";
        Gender = "";
    }

    public void SetCredentials(string username, string usernick)
    {
        UserName = username;
        Nick = usernick;
    }

    public void SetID(string id)
    {
        UserId = id;
    }

    public void SetBirthDate(string birthdate)
    {
        Birhdate = birthdate;
    }

    public void SetGender(string gender)
    {
        Gender = gender;
    }


}
