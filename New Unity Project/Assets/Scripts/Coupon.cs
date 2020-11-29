using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coupon : MonoBehaviour
{
    public string storeName;
    public string discount;
    public static List<string> deadObjects = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        if(deadObjects.Contains(name)) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ShowEmailEnterCanvas() {
        GameObject.Find("CouponManager").GetComponent<CouponManager>().ShowEmailInputCanvas();
        GameObject.Find("CouponManager").GetComponent<CouponManager>().tempStoreName = storeName;
        GameObject.Find("CouponManager").GetComponent<CouponManager>().tempDiscount = discount;
    }
    
   
    
    void OnTriggerEnter2D() {
        if(GameObject.Find("CouponManager").GetComponent<CouponManager>().emailAddress == "") {
            ShowEmailEnterCanvas();
        }
        else {
            GameObject.Find("CouponManager").GetComponent<CouponManager>().tempStoreName = storeName;
            GameObject.Find("CouponManager").GetComponent<CouponManager>().tempDiscount = discount;
            
            GameObject.Find("CouponManager").GetComponent<CouponManager>().ShowCouponFound();
            GameObject.Find("CouponManager").GetComponent<CouponManager>().SendEmail();
        }
        
        Destroy(this.gameObject);
        deadObjects.Add(name);
    }
}
