using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hand : MonoBehaviour
{

    private List<GameObject> cardList = new List<GameObject>();

    private int current_card = 0;

    public void add_card_to_hand(GameObject card) {  
        cardList.Add(card); 
    }

    public void remove_card_from_hand(GameObject card) 
    {  
        cardList.Remove(card);
        if(cardList.Count > 0)
        {
            if(current_card == cardList.Count) { 
                current_card = 0;
            }
            else if(current_card == 0)
            {
                current_card = cardList.Count - 1;
            }
            show_card();
        }
    }

    public void show_card()
    {
        cardList[current_card].SetActive(true);
    }

    public void hide_card()
    {
        cardList[current_card].SetActive(false);
    }

    public void next_card() {
        if (cardList.Count!=1) {
            hide_card();
            if (current_card == cardList.Count - 1)
            {
                current_card = 0;
            }
            else current_card++;
            show_card();
        }
    }

    public void previous_card()
    {
        if (cardList.Count != 1)
        {
            hide_card();
            if(current_card == 0)
            {
                current_card = cardList.Count - 1;
            }
            else current_card --;

            show_card();
        }
    }

}
