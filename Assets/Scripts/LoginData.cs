using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Keeping login data in class becuase in future if API calls are used the response will be stored in a class so simulating a similar scenario
public static class LoginData
{
    static string username = "admin";
    static string password = "qwerty";

    public static string GetUsername() { return username;}
    public static string GetPassword() { return password;}
}
