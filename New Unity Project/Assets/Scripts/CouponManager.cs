using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityCipher;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UE.Email;

public class CouponManager : MonoBehaviour
{

    private static bool created = false;
    public string emailAddress = "";
    
    public string tempStoreName;
    public string tempDiscount;
    GameObject couponFound;
    GameObject showEmailEnterCanvas;
    GameObject player;
    public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        couponFound = GameObject.Find("CouponFoundCanvas");
        couponFound.SetActive(false);
        
        showEmailEnterCanvas = GameObject.Find("EmailEnterCanvas");
        showEmailEnterCanvas.SetActive(false);
        
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static bool IsEmail(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }
    
    public void ShowEmailInputCanvas() {
        showEmailEnterCanvas.SetActive(true);
        player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = false;

    }
    
    public void CloseEmailInputCanvas() {
        showEmailEnterCanvas.SetActive(false);
        player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;

    }
    
    public void SubmitEmailAddress() {
        emailAddress = GameObject.Find("EmailInputField").GetComponent<InputField>().text;
        
        if(emailAddress != "" && CouponManager.IsEmail(emailAddress)) {
            showEmailEnterCanvas.SetActive(false);
            couponFound.SetActive(true);
            GameObject.Find("StoreNameText").GetComponent<Text>().text = tempStoreName;
            GameObject.Find("DiscountText").GetComponent<Text>().text = tempDiscount;
            SendEmail();
            player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;
        }
    }
    
    public void ShowCouponFound() {
        couponFound.SetActive(true);
        GameObject.Find("StoreNameText").GetComponent<Text>().text = tempStoreName;
        GameObject.Find("DiscountText").GetComponent<Text>().text = tempDiscount;
    }
    
    public void CloseCouponFound() {
        couponFound.SetActive(false);
    }
    
    public void SendEmail ()
    {
            if(emailAddress == null || emailAddress == "" || !CouponManager.IsEmail(emailAddress)) {
                return;
            }
            //string plainText = "ABCDEFGHIJKLMNOPQRST" + emailAddress + "\n" +  tempStoreName + "\n" +  tempDiscount;

            Email.SendEmailToken("modelmoxhambroadway@gmail.com", emailAddress, "Coupon for you", "You have a free coupon from Model Moxham Broadway!" + HTML.P + "Store Name: " + tempStoreName + HTML.P +  "Discount details: " + tempDiscount, "519c824c-9e03-40de-ac44-9c2ab54dd3a4");
/*
             //DUCK.Crypto.SimpleAESEncryption.AESEncryptedText encrypted = DUCK.Crypto.SimpleAESEncryption.Encrypt(plainText, "sxzRzirMPNdMfAfpbeTfE1wPsIk5VLvQ");
             MailMessage mail = new MailMessage();
 
             mail.From = new MailAddress("modelmoxhambroadway@gmail.com");
             mail.To.Add(emailAddress);
             mail.Subject = "Coupon for you";
             mail.Body = "You have a free coupon from Model Moxham Broadway!\nStore Name: " + tempStoreName + "\nDiscount details: " + tempDiscount;
 
             SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
             smtpServer.Port = 587;
             smtpServer.Credentials = new System.Net.NetworkCredential("modelmoxhambroadway@gmail.com", "billyblue123") as ICredentialsByHost;
             smtpServer.EnableSsl = true;
             ServicePointManager.ServerCertificateValidationCallback = 
                 delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                     { return true; };
             smtpServer.Send(mail);
             Debug.Log("success");
         */
    }
}
