using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speach_bubble_script : MonoBehaviour
{
    public TMP_Text bubble_text;

    public void setBubleTect(string text_to_put)
    {
        bubble_text.text = text_to_put;
    }
}
