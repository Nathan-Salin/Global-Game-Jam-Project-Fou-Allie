using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   

    public GameObject card_prefab;
    public Transform cardSlots;
    public int availableCardSlots;
    public Hand player_hand;

    private JokeContainer jokeContainer;

    
    public void DrawHand(){
        for(int i=0; i<availableCardSlots; i++){
            Joke joke=jokeContainer.get_random_joke();
            GameObject cardInHand = Instantiate(card_prefab, cardSlots);
            cardInHand.SetActive(false);
            Card card = cardInHand.GetComponent<Card>();
            card.hand = player_hand;
            card.setText(joke.get_full_joke());
            player_hand.add_card_to_hand(cardInHand);

        }
        player_hand.show_card();
    }

    // Start is called before the first frame update
    void Start()
    {   
        jokeContainer = new JokeContainer();
        DrawHand();
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
