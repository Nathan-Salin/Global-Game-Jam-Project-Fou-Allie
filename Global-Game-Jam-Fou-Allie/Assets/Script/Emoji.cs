﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji : MonoBehaviour
{

    public enum Name_of_Emoji
    {
        Magician_Hat,
        Magic,
        Weight,
        Food,
        Time,
        Queen,
        King,
        Party,
        Dancing_Woman,
        Dancing_Man,
        War,
        Running,
        Castle,
        Happy,
        Social,
        Repeat,
        Money,
        Rainbow,
        Horseman,
        Jump,
        Salutation,
        Shield,
        Cool_Dude,
        Thinking,
        Rock,
        Hockey,
        Snow,
        Up,
        Shop,
        Green,
        Croco,
        Discution,
        Insane,
        Laughing,
        Joker,
        Mirror,
        Smart,
        Wind,
        Diagonal,
        Spy,
        Sit,
        Stressed,
        Book,
        Doctor,
        Feet,
        Music,
        Love,
        One,
        Attraction,
        Politician,
        Vacation,
        Failing,
        Stadium,
        Down
    };

    private static Dictionary<Name_of_Emoji, string> Emoji_To_UTF = new Dictionary<Name_of_Emoji, string>()
    {
        { Name_of_Emoji.Magician_Hat, "Magician_Hat" },
        { Name_of_Emoji.Magic, "Magic" },
        { Name_of_Emoji.Weight, "Weight" },
        { Name_of_Emoji.Food, "Food" },
        { Name_of_Emoji.Queen, "Queen" },
        { Name_of_Emoji.King, "King" },
        { Name_of_Emoji.Party, "Party" },
        { Name_of_Emoji.Dancing_Woman, "Dancing_Woman" },
        { Name_of_Emoji.Dancing_Man, "Dancing_Man" },
        { Name_of_Emoji.War, "War" },
        { Name_of_Emoji.Running, "Running" },
        { Name_of_Emoji.Castle, "Castle" },
        { Name_of_Emoji.Happy, "Happy" },
        { Name_of_Emoji.Time, "Time" },
        { Name_of_Emoji.Social, "Social" },
        { Name_of_Emoji.Repeat, "Repeat" },
        { Name_of_Emoji.Money, "Money" },
        { Name_of_Emoji.Rainbow, "Rainbow" },
        { Name_of_Emoji.Horseman, "Horseman" },
        { Name_of_Emoji.Jump, "Jump" },
        { Name_of_Emoji.Salutation, "Salutation" },
        { Name_of_Emoji.Shield, "Shield" },
        { Name_of_Emoji.Cool_Dude, "Cool_Dude" },
        { Name_of_Emoji.Thinking, "Thinking" },
        { Name_of_Emoji.Rock, "Thinking" },
        { Name_of_Emoji.Hockey, "Hockey" },
        { Name_of_Emoji.Snow, "Snow" },
        { Name_of_Emoji.Up, "Up" },
        { Name_of_Emoji.Shop, "Shop" },
        { Name_of_Emoji.Green, "Green" },
        { Name_of_Emoji.Croco, "Croco" },
        { Name_of_Emoji.Discution, "Discution" },
        { Name_of_Emoji.Insane, "Insane" },
        { Name_of_Emoji.Laughing, "Laughing" },
        { Name_of_Emoji.Joker, "Joker" },
        { Name_of_Emoji.Mirror, "Mirror" },
        { Name_of_Emoji.Smart, "Smart" },
        { Name_of_Emoji.Wind, "Wind" },
        { Name_of_Emoji.Diagonal, "Diagonal" },
        { Name_of_Emoji.Spy, "Spy" },
        { Name_of_Emoji.Sit, "Sit" },
        { Name_of_Emoji.Stressed, "Stressed" },
        { Name_of_Emoji.Book, "Book" },
        { Name_of_Emoji.Doctor, "Doctor" },
        { Name_of_Emoji.Feet, "Feet" },
        { Name_of_Emoji.Music, "Music" },
        { Name_of_Emoji.Love, "Love" },
        { Name_of_Emoji.One, "One" },
        { Name_of_Emoji.Politician, "Politician" },
        { Name_of_Emoji.Vacation, "Vacation" },
        { Name_of_Emoji.Stadium, "Stadium" },
        { Name_of_Emoji.Failing, "Failing" },
        { Name_of_Emoji.Down, "Down" },
        {Name_of_Emoji.Attraction,"Attraction"},
    };

    public static string get_code_for_Emoji(Name_of_Emoji name)
    {
        return Emoji_To_UTF[name];
    }

    public static string get_all_sprite_ref_for_emoji(List<Name_of_Emoji> list)
    {
        string result ="";
        for (int i = 0; i < list.Count; i ++) {
            result += ("<sprite name=" + get_code_for_Emoji(list[i]) + "> ");
        }
        return result;
    }

}
