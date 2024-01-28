using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    private AudioManager audioManager;
    public int nb_of_clap_to_hear = 4;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        for (int i = 0; i < nb_of_clap_to_hear; i++)
        {
            audioManager.PlayRandomClap();
        }
    }

    public static void Go_back_to_main_menu()
    {
        SceneManager.LoadScene(0);
    }
}
