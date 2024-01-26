using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public void DrawHand(){
        Card randCard = deck[Random.Range(0, deck.Count)];
        for(int i=0; i<availableCardSlots.Length; i++){
            if(availableCardSlots[i]==true){
                randCard.gameObject.SetActive(true);
                randCard.handIndex=i;
                randCard.transform.position = cardSlots[i].position;
                availableCardSlots[i]=false;
                deck.Remove(randCard);
                return;
            }
        }
    }

















    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
