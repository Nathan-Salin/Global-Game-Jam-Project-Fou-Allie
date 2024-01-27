using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   

    public GameObject card_prefab;
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    
    public void DrawHand(){
        for(int i=0; i<availableCardSlots.Length; i++){
            if(availableCardSlots[i]==true){
                Instantiate(card_prefab, cardSlots[i]);
                availableCardSlots[i]=false;
                return;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        while(availableCardSlots[availableCardSlots.Length-1]!=false){
            DrawHand();
            
        }
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
