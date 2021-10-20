using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gmngr : MonoBehaviour
{ 
  public float timeValue = 20;
  public Text Tmrtxt;
    public Text Tmrtxt1;
    public Text Tmrtxt2;
    public Text Ltxt;
    public Text Ltxt1;
    public Text Ltxt2;
    public Text Ltxt3;

    // public Button MBtn;


   

  
    public GameObject DG1;
    public GameObject DG2;
    public GameObject DG3;


    public int b = 0;

    void Update()
    {
        DisplayTime(timeValue);

        
        if (timeValue>0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            
        }
        if (timeValue == 0) {
            if (b == 0 || b == 1 || b == 2 || b == 3 || b == 4)
            {
                
                timeValue = 20;


                b++;
                Debug.Log(b);
                
                Ltxt.text = b.ToString();
                Ltxt1.text = b.ToString();
                Ltxt2.text = b.ToString();
                Ltxt3.text = b.ToString();




            }

            if (b == 5)
            {

                 timeValue = 0;
                Tmrtxt.text = "Full";

            }
        }
       



    }

    void DisplayTime (float timedsp)
    {
        
        if(timedsp <0)
        {
            timedsp = 0;
        }
         float minutes = 0;
         float seconds =  Mathf.FloorToInt(timedsp % 20);
        Tmrtxt.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
        Tmrtxt1.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        Tmrtxt2.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

   public  void OnClick()
    {
        if (b == 1 || b == 2 || b == 3 || b == 4)
        {
           
           
            DG1.SetActive(true);

        }
        if (b == 0)
        {

           
            DG2.SetActive(true);

        }
        if (b == 5)
        {

         
            DG3.SetActive(true);

        }
    }

    public void OnClick1()
    {
        if (b == 0 || b == 1 || b == 2 || b == 3 || b == 4)
        {

            b++;
            Ltxt.text = b.ToString();
            Ltxt1.text = b.ToString();
            Ltxt2.text = b.ToString();
            Ltxt3.text = b.ToString();
        }
       

        if (b == 5)
        {

            b =5;
            Ltxt.text = b.ToString();
            Ltxt1.text = b.ToString();
            Ltxt2.text = b.ToString();
            Ltxt3.text = b.ToString();

            timeValue = 0;
            Tmrtxt.text = "Full";
        }
    }

    public void OnClick2()
    {
        if (b == 1 || b == 1 || b == 2 || b == 3 || b == 5)
        {

            b--;
            Ltxt.text = b.ToString();
            Ltxt1.text = b.ToString();
            Ltxt2.text = b.ToString();
            Ltxt3.text = b.ToString();
        }

        if (b == 0)
        {

            b=0;
            Ltxt.text = b.ToString();
            Ltxt1.text = b.ToString();
            Ltxt2.text = b.ToString();
            Ltxt3.text = b.ToString();
        }
       
    }

}
