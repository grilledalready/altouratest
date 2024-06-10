using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Button submitButton;

    public delegate void UILoginEventHandler(string username, string password);
    public static event UILoginEventHandler OnUILoginEvent;

    private void Start()
    {
        submitButton.onClick.AddListener(() =>
        {
            OnUILoginEvent?.Invoke(usernameField.text, passwordField.text);
        });
    }
}
