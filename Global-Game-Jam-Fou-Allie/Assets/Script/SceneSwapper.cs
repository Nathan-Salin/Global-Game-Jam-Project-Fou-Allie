using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{

    public static void Go_back_to_main_menu()
    {
        SceneManager.LoadScene(0);
    }
}
