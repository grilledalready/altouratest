using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject loginScreen;
    public GameObject homepageScreen;
    public GameObject mainPage;

    private void OnEnable()
    {
        LoginManager.OnAuthorizedEvent += HandleScreens;
    }


    private void OnDisable()
    {
        LoginManager.OnAuthorizedEvent -= HandleScreens;
    }

    private void HandleScreens(bool authorized)
    {
        homepageScreen.SetActive(authorized);
        loginScreen.SetActive(!authorized);
    }

    public void HandleMainScreen(bool enable)
    {
        mainPage.SetActive(enable);
    }

}
