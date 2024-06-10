using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public delegate void AuthorizationEventHandler(bool authorized);
    public static event AuthorizationEventHandler OnAuthorizedEvent;

    private void OnEnable()
    {
       LoginUI.OnUILoginEvent += Authorize;
    }

    private void OnDisable()
    {
        LoginUI.OnUILoginEvent -= Authorize;
    }

    public void Authorize(string username, string password)
    {
        if (username != LoginData.GetUsername())
        {
            print("Incorrect Username");

            return;
        }

        if (password != LoginData.GetPassword())
        {
            print("Incorrect Password");

            return;
        }

        print("Authorized");

        OnAuthorizedEvent?.Invoke(true);
    }
}
