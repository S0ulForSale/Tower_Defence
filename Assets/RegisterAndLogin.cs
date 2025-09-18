using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Microsoft.VisualBasic.Logging;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;
//using System.Windows.Forms;


public class RegisterAndLogin : MonoBehaviour
{
    public GameObject RegisterUI;
    public GameObject LoginUI;
    public TMP_InputField UsernameR;
    public TMP_InputField PasswordR;
    public TMP_InputField Password2R;
    public TMP_InputField PasswordL;
    public TMP_InputField UsernameL;
    
    TcpClient client;
    NetworkStream stream;
    // Start is called before the first frame update
    void Start()
    {
        RegisterUI.SetActive(true);
    }
    public void Login()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 8080);
            stream = client.GetStream();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка підключення до сервера: {ex.Message}");
        }

        try
        {
            string LL = UsernameL.text;
            string PL = PasswordL.text;
            int id = 1;
            string data = $"{LL}|{PL}|{id}";
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            stream.Write(bytes, 0, bytes.Length);

            bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);
            string confirmationMessage = Encoding.ASCII.GetString(bytes, 0, bytesRead);

            Console.WriteLine($"Логін: {confirmationMessage}");

            // Очищаємо поля введення
            UsernameL.text = string.Empty;
            PasswordL.text = string.Empty;
            SceneManager.LoadScene(1);            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка логіну: {ex.Message}");
        }

    }
    public void ToRegister()
    {
        LoginUI.SetActive(false);
        RegisterUI.SetActive(true);
    }
    public void Register()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 8080);
            stream = client.GetStream();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка підключення до сервера: {ex.Message}");
        }

        try
        {
            string LR = UsernameR.text;
            string PR = PasswordR.text;
            string PR2 = Password2R.text;
            int id = 0;
            if(PR == PR2)
            {
                string data = $"{LR}|{PR}|{id}";
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                stream.Write(bytes, 0, bytes.Length);

                bytes = new byte[1024];
                int bytesRead = stream.Read(bytes, 0, bytes.Length);
                string confirmationMessage = Encoding.ASCII.GetString(bytes, 0, bytesRead);

                Console.WriteLine($"Реєстрація: {confirmationMessage}");

                UsernameR.text = string.Empty;
                PasswordR.text = string.Empty;
                Password2R.text = string.Empty;
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка реєстрації: {ex.Message}");
        }
    }
    public void ToLogin()
    {
        LoginUI.SetActive(true);
        RegisterUI.SetActive(false);
    }
}
