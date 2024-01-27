using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CardText : MonoBehaviour
{
    private string[] test=new string[3];
    
    public TMP_Text cardText;
    public bool hasText;
    // Start is called before the first frame update
    public void changeText()
    {
        
        int index=UnityEngine.Random.Range(0, test.Length);
        cardText.text = test[index];
        for(int i=index; i<test.Length-1;i++)
        {
            test[i]=test[i+1];
        }
        Array.Resize(ref test, test.Length-1);
        hasText=true;
        
    }

    void Start(){
        test[0]="1";
        test[1]="2";
        test[2]="3";

        changeText();
        
    }
    void Update()
    {
        
    }
}
