using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using TMPro;
using System;

public class AuthManager : MonoBehaviour
{
    private Firebase.Auth.FirebaseAuth auth; // Managing authentication

    [SerializeField] private TMP_InputField emailField;
    [SerializeField] private TMP_InputField passwordField;


    void Start()
    {

    }

    void Update()
    {

    }

    void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance; // Initializing authentication object 
    }

    // Log in function 
    public void Login()
    {
        // Log in with provided function from firebase
        auth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("Log in is canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Log in failed : " + task.Exception);
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Log in success : {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }

    // Sign in function 
    public void Singin()
    {
        // Sign in with provided function from firebase
        auth.CreateUserWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("Sign in is canceled");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Sign in failed : " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Sign in success: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }
}
