using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joke : MonoBehaviour
{
    private string first_part_of_joke = null;
    private string second_part_of_joke = null;

    private List<Emoji.Name_of_Emoji> joke_related_topics;

    public Joke(string text_1, string text_2, List<Emoji.Name_of_Emoji> list_emoji) {
        first_part_of_joke = text_1;
        second_part_of_joke= text_2;
        joke_related_topics = list_emoji;
    }

    public string get_first_part_of_joke()
    {
        return first_part_of_joke;
    }

    public string get_second_part_of_joke()
    {
        return second_part_of_joke;
    }

    public string get_full_joke()
    {
        return first_part_of_joke + second_part_of_joke;
    }

    public List<Emoji.Name_of_Emoji> get_related_topics()
    {
        return joke_related_topics;
    }
}
