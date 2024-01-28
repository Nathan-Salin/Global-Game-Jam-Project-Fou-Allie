using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{

    public bool hasBeenPlayed;
    public int handIndex;
    public bool hasText;
    public bool hasBeenHovered;
    public TMP_Text cardText;
    public Joke card_joke;

    public GameManager gm;

    public Hand hand;
    void Start()
    {
       
    }

    private void OnMouseDown(){
        if(hasBeenPlayed==false && gm.gameHasEnded != true){
            transform.position += Vector3.down * 3;
            transform.position += Vector3.forward * 3;
            hasBeenPlayed = true;
            destroyCard();
        }
    }

    private void OnMouseEnter(){
        if(hasBeenPlayed==false && hasBeenHovered==false && gm.gameHasEnded != true){
            transform.localScale +=new Vector3(0.02f, 0.0f,0.02f);
        }
        
    }
    private void OnMouseExit(){
        if(hasBeenPlayed==false && hasBeenHovered==false && gm.gameHasEnded != true){
            transform.localScale += new Vector3(-0.02f, 0f,-0.02f);
        }
    }
    public void setText(string text)
    {
        if(hasText==false){
            cardText.text = text;  
            hasText=true;
        }
        
    }

    private void destroyCard(){
        hand.remove_card_from_hand(gameObject);
        Destroy(gameObject);
    }











    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
  
    }
}
