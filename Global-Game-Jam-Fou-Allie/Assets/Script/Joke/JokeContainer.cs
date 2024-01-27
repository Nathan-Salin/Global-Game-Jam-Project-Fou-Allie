using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Joke_Container : MonoBehaviour
{

    private List<Joke> jokeList = new List<Joke>();
    private List<Boolean> jokeListChecked = new List<bool>();

    private List<string> parts_one = new List<string>()
    {
        "Quelle est le sport pr�f�r� des Tours ?",
        "Quelle l�attraction favorite d�une tours ?",
        "Comment appelle-t-on un fou qui fait des farces ?",
        "Pourquoi le fou n'est-il jamais bon pour donner la m�t�o ?",
        "Comment le roi �chappait-il aux imp�ts ?",
        "Qu'est-ce qui rend les pions si optimistes ?",
        "Comment appelle-t-on un pion qui aime la magie ?"

    };
    private List<string> parts_two = new List<string>()
    {
        "Le �roquet� sur glace !",
        "Le tourniquet ! ",
        "Un fou-rire !",
        "Parce qu'il ne peut jamais pr�voir dans quelle direction le vent va tourner !",
        "Il se cachait derri�re ses pions.",
        "Ils voient toujours la promotion � la fin du tunnel.",
        "Un piondini !"
    };

    private List<List<Emoji.Name_of_Emoji>> emojis_list = new List<List<Emoji.Name_of_Emoji>>()
    {
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Hockey, Emoji.Name_of_Emoji.Snow, Emoji.Name_of_Emoji.Stadium},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Attraction, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Insane, Emoji.Name_of_Emoji.Laughing},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Wind, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Spy, Emoji.Name_of_Emoji.King},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Rainbow, Emoji.Name_of_Emoji.Happy},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Magician_Hat, Emoji.Name_of_Emoji.Magic},
    };


    void Start()
    {
        for (int i = 0; i < parts_one.Count; i++)
        {
            jokeList.Add(new(parts_one[i], parts_two[i], emojis_list[i]));
            jokeListChecked.Add(false);
        }
    }

   
    public Joke get_random_joke()
    {
        int random_index = UnityEngine.Random.Range(0,jokeList.Count);
        return jokeList[random_index];
    }
}
