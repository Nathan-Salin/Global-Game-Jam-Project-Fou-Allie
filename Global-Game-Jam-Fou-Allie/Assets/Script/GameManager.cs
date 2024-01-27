using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   

    public GameObject card_prefab;
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    private JokeContainer jokeContainer;

    
    public void DrawHand(){
        for(int i=0; i<availableCardSlots.Length; i++){
            if(availableCardSlots[i]==true){
                Joke joke=jokeContainer.get_random_joke();
                GameObject cardInHand = Instantiate(card_prefab, cardSlots[i]);
                Card card=gameObject.GetComponent<Card>();
                card.setText(joke.get_full_joke());
                availableCardSlots[i]=false;
                return;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        jokeContainer = new JokeContainer();
        while(availableCardSlots[availableCardSlots.Length-1]!=false){
            DrawHand();
            
        }
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
