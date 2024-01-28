using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{   
    private List<Joke> jokes = new List<Joke>();
    private List<GameObject> cards_in_game = new List<GameObject>();
    private Joke current_joke = null;
    public bool gameHasEnded=false;
    public GameObject card_prefab;
    public Transform cardSlots;
    public int availableCardSlots;
    public Hand player_hand;
    public Speach_bubble_script speach_Bubble_Script;
    

    private JokeContainer jokeContainer;

    private AudioManager audioManager;

    public int number_of_sound_played = 10;
    private int yes_sound_played = 0;
    private int no_sound_played = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        jokeContainer = new JokeContainer();
        DrawHand();
        choose_next_joke();
    }

    private IEnumerator WaitForXseconds(float x)
    {
        yield return new WaitForSecondsRealtime(x);
    }
    private IEnumerator GameOverWithDelay(float x)
    {
        yield return StartCoroutine(WaitForXseconds(x));
        Restart();
    }


    private void DrawHand(){
        for(int i=0; i<availableCardSlots; i++){

            Joke joke=jokeContainer.get_random_joke();
            jokes.Add(joke);

            GameObject cardInHand = Instantiate(card_prefab, cardSlots);
            cardInHand.SetActive(false);
 
            cards_in_game.Add(cardInHand);

            Card card = cardInHand.GetComponent<Card>();
            card.hand = player_hand;
            card.gm = this;
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

    private void GameOver(){
        if(gameHasEnded==false){
            gameHasEnded=true;
            player_hand.hide_card();
            player_hand.hide_UI();
            StartCoroutine(GameOverWithDelay(8));
        }
    }

    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Play_game_over_sounds()
    {
        if (no_sound_played < number_of_sound_played)
        {
            audioManager.PlayRandomBoo();
            no_sound_played++;
        }
        else
        {
            // Arrêter l'invocation après dix appels
            CancelInvoke("Play_game_over_sonds");
        }
    }

    private void Play_ok_sounds()
    {
        if (yes_sound_played < number_of_sound_played)
        {
            audioManager.PlayRandomLaughing();
            yes_sound_played++;
        }
        else
        {
            // Arrêter l'invocation après dix appels
            CancelInvoke("Play_ok_sounds");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Utiliser le temps écoulé pour déterminer le moment du prochain spawn
        
        for (int i = 0; i < cards_in_game.Count; i++) {
            if (cards_in_game[i] == null)
            {   
                Joke joke_played = jokes[i];
                jokes.RemoveAt(i); 
                cards_in_game.RemoveAt(i);
                bool isJokeRight = is_joke_right(joke_played);
                if (!isJokeRight) {
                    InvokeRepeating("Play_game_over_sounds", 2f, 0.1f);
                    no_sound_played = 0;
                    GameOver();
                    Debug.Log("U FAILED SON !");
                }
                else
                {

                    yes_sound_played = 0;
                    InvokeRepeating("Play_ok_sounds", 2f, 0.1f);
                    Debug.Log("NICE JOB !");
                    if(cards_in_game.Count == 0) break;
                    choose_next_joke();
                }
            }
        }

        //Add victory_scene
        if(cards_in_game.Count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            Debug.Log("U WON !");
        }
    }
}
