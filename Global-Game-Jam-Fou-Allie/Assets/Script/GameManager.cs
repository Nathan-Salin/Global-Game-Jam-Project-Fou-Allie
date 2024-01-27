using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    private List<Joke> jokes = new List<Joke>();
    private List<GameObject> cards_in_game = new List<GameObject>();
    private Joke current_joke = null;

    public GameObject card_prefab;
    public Transform cardSlots;
    public int availableCardSlots;
    public Hand player_hand;
    public Speach_bubble_script speach_Bubble_Script;


    private JokeContainer jokeContainer;


    private void DrawHand(){
        for(int i=0; i<availableCardSlots; i++){

            Joke joke=jokeContainer.get_random_joke();
            jokes.Add(joke);

            GameObject cardInHand = Instantiate(card_prefab, cardSlots);
            cardInHand.SetActive(false);
            cards_in_game.Add(cardInHand);

            Card card = cardInHand.GetComponent<Card>();
            card.hand = player_hand;
            card.card_joke = joke;
            card.setText(joke.get_full_joke());

            player_hand.add_card_to_hand(cardInHand);

        }
        player_hand.show_card();
    }

    private bool is_joke_right(Joke joke)
    {
        return joke == current_joke;
    }

    private void choose_next_joke()
    {
        int random_joke = UnityEngine.Random.Range(0, cards_in_game.Count);
        Joke joke_choosen = jokes[random_joke];
        current_joke = joke_choosen;
        string new_text = Emoji.get_all_sprite_ref_for_emoji(joke_choosen.get_related_topics());
        speach_Bubble_Script.setBubleTect(new_text);
    }

    // Start is called before the first frame update
    void Start()
    {   
        jokeContainer = new JokeContainer();
        DrawHand();
        choose_next_joke();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cards_in_game.Count; i++) {
            if (cards_in_game[i] == null)
            {
                cards_in_game.RemoveAt(i);
                if (cards_in_game.Count == 0) break;
                bool isJokeRight = is_joke_right(jokes[i]);
                jokes.RemoveAt(i);
                if (!isJokeRight) {
                    //Add Game over sequences ! 
                    Debug.Log("U FAILED SON !");
                }
                else
                {
                    Debug.Log("NICE JOB !");
                }
                choose_next_joke();
            }
        }

        //Add victory_scene
        if(cards_in_game.Count == 0)
        {
            Debug.Log("U WON !");
        }
    }
}
