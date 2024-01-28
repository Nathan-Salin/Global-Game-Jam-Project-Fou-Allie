using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hand : MonoBehaviour
{
    public GameManager gm; 
    private List<GameObject> cardList = new List<GameObject>();

    public Canvas hand_ui;

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
        Debug.Log(gm.gameHasEnded);
        if (cardList.Count!=1 && gm.gameHasEnded != true) {
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
        Debug.Log(gm.gameHasEnded);
        if (cardList.Count != 1 && gm.gameHasEnded != true)
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

    public void hide_UI(){
        hand_ui.enabled = false;
    }

    public void show_UI(){
        hand_ui.enabled = true;
    }

}
