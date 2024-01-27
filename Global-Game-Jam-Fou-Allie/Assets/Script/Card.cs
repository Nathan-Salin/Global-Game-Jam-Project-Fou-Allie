using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gm;
    void Start()
    {
        gm=FindObjectOfType<GameManager>();
    }

    private void OnMouseDown(){
        if(hasBeenPlayed==false){
            transform.position += Vector3.down * 3;
            transform.position += Vector3.forward * 3;
            hasBeenPlayed =true;
            StartCoroutine (SpawnDelay());
            gm.availableCardSlots[handIndex]=true;
        }
    }

    private IEnumerator SpawnDelay(){
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }










    /*// Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
