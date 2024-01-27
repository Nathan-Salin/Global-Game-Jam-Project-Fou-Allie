using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class JokeContainer
{

    private List<Joke> jokeList = new List<Joke>();
    private List<Boolean> jokeListChecked = new List<bool>();

    private List<string> parts_one = new List<string>()
    {
        "Quelle est le sport préféré des Tours ?\n",
        "Quelle l'attraction favorite d'une tours ?\n",
        "Comment appelle-t-on un fou qui fait des farces ?\n",
        "Pourquoi le fou n'est-il jamais bon pour donner la météo ?\n",
        "Comment le roi échappait-il aux impôts ?\n",
        "Qu'est-ce qui rend les pions si optimistes ?\n",
        "Comment appelle-t-on un pion qui aime la magie ?\n",
        "Comment appelle-t-on un pion qui a des problèmes de poids ?\n",
        "Qu'est-ce qu'un roi dit à une reine qui prend trop de temps pour se préparer ?\n",
        "Comment les pions font-ils la fête ?\n",
        "Qu'est-ce qu'un pion a dit à un autre pion pendant la guerre ?\n",
        "Comment le pion se sent-il après avoir été promu ?\n",
        "Comment les pions se détendent-ils après une bataille ?\n",
        "Qu'est-ce qui rend les pions si sociables ?\n",
        "Pourquoi les pions n'ont-ils jamais de problèmes financiers ?\n",
        "Quel est le rêve secret de chaque pion ?\n",
        "Pourquoi les cavaliers aiment-ils les champs de batailles ?\n",
        "Comment les cavaliers se saluent-ils avant une bataille ?\n",
        "Pourquoi les cavaliers ne sont-ils jamais en retard à la guerre ?\n",
        "Pourquoi les cavaliers ne sont-ils jamais stressés sur le champs de bataille ?\n",
        "Comment les cavaliers résolvent-ils les problèmes ?\n",
        "Pourquoi les tours ne sont-elles jamais invitées aux concerts de rock ?\n",
        "Quelle est l’attraction favorite d’une tour ?\n",
        "Qu'est-ce qu'une tour dit à une autre tour lors d'une soirée élégante ?\n",
        "Comment les tours se saluent-elles avant une partie ?\n",
        "Qu'est-ce qu'une tour dit à une autre tour qui prend trop de temps à jouer ?\n",
        "Comment les tours font-elles leurs courses ?\n",
        "Quel est le reptile préféré des échecs ?\n",
        "Comment appelle-t-on deux fous qui discutent entre eux pendant une partie d'échecs ?\n",
        "Pourquoi le fou est-il si sage ?\n",
        "Le fou écrit un livre sur ses expériences d'échecs. Le titre ?\n",
        "Quel est le comble pour un Roi ?\n",
        "Pourquoi le roi aux échecs est-il toujours stressé ?\n",
        "Pourquoi le roi aux échecs est-il le meilleur danseur ?\n",
        "Comment le roi aux échecs appelle-t-il son médecin ?\n",
        "Quel est le genre de musique préféré du roi aux échecs ?\n",
        "Comment le roi aux échecs exprime-t-il son amour ?\n",
        "Pourquoi la dame est-elle la meilleure pièce d'échecs ?\n",
        "Pourquoi la reine serait-elle une excellente politicienne ?\n",
        "Pourquoi la reine des échecs est-elle une excellente danseuse ?\n",
        "Pourquoi la reine est-elle la pièce préférée des magiciens ?\n",
        "Pourquoi la reine a-t-elle besoin de vacances ?\n",
        "Quelle musique la reine aime-t-elle écouter ?\n",
        "Comment la reine gère-t-elle les situations difficiles ?\n"
    };
    private List<string> parts_two = new List<string>()
    {
        "Le roquet sur glace !\n",
        "Le tourniquet !\n ",
        "Un fou-rire !\n",
        "Parce qu'il ne peut jamais prévoir dans quelle direction le vent va tourner !\n",
        "Il se cachait derrière ses pions !\n",
        "Ils voient toujours la promotion à la fin du tunnel !\n",
        "Un piondini !\n",
        "Un pion-lourd !\n",
        "On est déjà en échec et mat, dépêche-toi !\n",
        "Ils dansent au rythme du rock and pion !\n",
        "Avance, la vie est trop courte pour rester en arrière !\n",
        "Comme une reine !\n",
        "En prenant un bon bain 'en avant' !\n",
        "Ils aiment faire des amis en 'avancant' dans la vie !\n",
        "Parce qu'ils sont toujours prêts à sacrifier un peu pour le bien de l'équipe !\n",
        "Devenir une dame et régner en maître sur l'échiquier !\n",
        "Parce qu'ils sont experts en 'sauts' spectaculaires !\n",
        "Ils disent : 'Que la cavalerie commence !'\n'",
        "Parce qu'ils sont experts pour arriver en 'L'igne !\n",
        "Parce qu'ils savent comment 'cavaler' rapidement sur l'échiquier sans se soucier des obstacles !\n",
        "Ils prennent toujours une 'approche en L' pour trouver la meilleure solution !\n",
        "Parce qu'elles ont du mal à suivre le rythme 'roque' de la musique !\n",
        "Le tourniquet !\n",
        "'Tu as l'air vraiment 'roquet' ce soir !'\n",
        "'Salut, je vois que tu es bien 'élevée' aujourd'hui !'\n",
        "'Tu es vraiment en train de 'tourner' autour du pot !'\n",
        "Elles montent et descendent les allées en quête des meilleures offres !\n",
        "Le 'rocaïman' !\n",
        "Un échec mental !\n",
        "Parce qu'il a toujours une perspective intéressante !\n",
        "'Fous Rires et Mouvements En Diagonale!'\n",
        "Se faire poser une couronne par son dentiste !\n",
        "Parce qu'il est toujours échec et mat !\n",
        "Parce qu'il a les pas du roi !\n",
        "Le docteur Échec et Mat !\n",
        "Le rock, bien sûr !\n",
        "En disant à sa reine : 'Tu es mon seul mat, et ma vie serait échec sans toi !'\n",
        "Parce qu'elle sait comment diriger toutes les situations !\n",
        "Parce qu'elle peut se déplacer dans toutes les directions et garder tout le monde sous contrôle !\n",
        "Parce qu'elle a toujours des déplacements gracieux ! \n",
        "Parce qu'elle peut se téléporter instantanément sur n'importe quelle case !\n",
        "Parce qu'elle est toujours sous pression et a besoin de prendre du temps pour elle, loin des échecs !\n",
        "'Queen' bien sûr !\n",
        "En prenant les bonnes décisions et en 'matant' tous les problèmes.\n"
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
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Weight, Emoji.Name_of_Emoji.Food},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Time, Emoji.Name_of_Emoji.King, Emoji.Name_of_Emoji.Queen},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Party, Emoji.Name_of_Emoji.Dancing_Woman, Emoji.Name_of_Emoji.Dancing_Man},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.War, Emoji.Name_of_Emoji.Running},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Happy, Emoji.Name_of_Emoji.Queen},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.War, Emoji.Name_of_Emoji.Time},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Social, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Money, Emoji.Name_of_Emoji.Social},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Magic, Emoji.Name_of_Emoji.Queen},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Rainbow, Emoji.Name_of_Emoji.Happy},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Horseman, Emoji.Name_of_Emoji.Jump},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Salutation, Emoji.Name_of_Emoji.Horseman, Emoji.Name_of_Emoji.Shield},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Time, Emoji.Name_of_Emoji.Horseman, Emoji.Name_of_Emoji.Shield},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Cool_Dude, Emoji.Name_of_Emoji.Horseman, Emoji.Name_of_Emoji.Jump},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Thinking, Emoji.Name_of_Emoji.Horseman, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Rock, Emoji.Name_of_Emoji.Failing},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Dancing_Woman, Emoji.Name_of_Emoji.Dancing_Man},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Salutation, Emoji.Name_of_Emoji.Up},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Time, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Shop, Emoji.Name_of_Emoji.Repeat, Emoji.Name_of_Emoji.Up, Emoji.Name_of_Emoji.Down},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Green, Emoji.Name_of_Emoji.Croco},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Thinking, Emoji.Name_of_Emoji.Failing, Emoji.Name_of_Emoji.Discution},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Smart, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Book, Emoji.Name_of_Emoji.Insane, Emoji.Name_of_Emoji.Diagonal},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Stressed, Emoji.Name_of_Emoji.Sit},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Stressed, Emoji.Name_of_Emoji.Failing},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Dancing_Woman, Emoji.Name_of_Emoji.Dancing_Man, Emoji.Name_of_Emoji.Feet},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Doctor, Emoji.Name_of_Emoji.Failing},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Rock, Emoji.Name_of_Emoji.Music},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Love, Emoji.Name_of_Emoji.Queen, Emoji.Name_of_Emoji.Failing},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Queen, Emoji.Name_of_Emoji.One},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Politician, Emoji.Name_of_Emoji.Repeat},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Dancing_Woman, Emoji.Name_of_Emoji.Dancing_Man},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Magician_Hat, Emoji.Name_of_Emoji.Magic},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Vacation, Emoji.Name_of_Emoji.Repeat, Emoji.Name_of_Emoji.Failing},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Rock, Emoji.Name_of_Emoji.Music},
        new List<Emoji.Name_of_Emoji> { Emoji.Name_of_Emoji.Thinking, Emoji.Name_of_Emoji.Repeat},

    };


    public JokeContainer()
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
        while(jokeListChecked[random_index]==true){random_index = UnityEngine.Random.Range(0,jokeList.Count);}
        
        jokeListChecked[random_index] = true;
        return jokeList[random_index];
    }
}
