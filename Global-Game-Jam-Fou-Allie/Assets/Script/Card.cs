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
    private GameManager gm;
    public TMP_Text cardText;
    void Start()
    {
        gm=FindObjectOfType<GameManager>();
    }

    private void OnMouseDown(){
        if(hasBeenPlayed==false){
            transform.position += Vector3.down * 3;
            transform.position += Vector3.forward * 3;
            hasBeenPlayed =true;
            StartCoroutine (destroyCard());
            gm.availableCardSlots[handIndex]=true;
        }
    }

    private void OnMouseEnter(){
        if(hasBeenPlayed==false && hasBeenHovered==false){
            transform.localScale +=new Vector3(0.5f, 0.0f,0.5f);
        }
        
    }
    private void OnMouseExit(){
        if(hasBeenPlayed==false && hasBeenHovered==false){
            transform.localScale += new Vector3(-0.5f, 0f,-0.5f);
        }
    }
    /*public void setText()
    {
        if(hasText==false){
            int index=Random.Range(0, jokes.Count);
            cardText.text = jokes[index];
            Debug.Log(jokes[index]);
            jokes.RemoveAt(index);
            hasText=true;
        }
        
    }*/

    private IEnumerator destroyCard(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }











    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
