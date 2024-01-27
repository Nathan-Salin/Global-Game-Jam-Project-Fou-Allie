using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joke : MonoBehaviour
{
    public string first_part_of_joke = null;
    public string second_part_of_joke = null;


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
}
