using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hand : MonoBehaviour
{

    private List<GameObject> cardList = new List<GameObject>();

    private int current_card = 0;

    public Button left_rotation;
    public Button right_rotation;

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
        Debug.Log("cardList Size = " + cardList.Count);
        Debug.Log("current_card = " + current_card);
        if (cardList.Count!=1) {
            hide_card();
            if (current_card == cardList.Count - 1)
            {
                current_card = 0;
            }
            else current_card++;
            Debug.Log("cardList Size After = " + cardList.Count);
            Debug.Log("current_card After = " + current_card);
            show_card();
        }
    }

    public void previous_card()
    {
        Debug.Log("cardList Size = " + cardList.Count);
        Debug.Log("current_card = " + current_card);
        if (cardList.Count != 1)
        {
            hide_card();
            if(current_card == 0)
            {
                current_card = cardList.Count - 1;
            }
            else current_card --;

            Debug.Log("cardList Size After = " + cardList.Count);
            Debug.Log("current_card After = " + current_card);
            show_card();
        }
    }

    private float dernierChangementDeCarte = 0f;
    private float delaiEntreChangements = 1f; // Un délai d'une seconde entre chaque changement

    public void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Time.time - dernierChangementDeCarte >= delaiEntreChangements)
            {
                next_card();
                dernierChangementDeCarte = Time.time;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Time.time - dernierChangementDeCarte >= delaiEntreChangements)
            {
                previous_card();
                dernierChangementDeCarte = Time.time;
            }
        }
    }



}
