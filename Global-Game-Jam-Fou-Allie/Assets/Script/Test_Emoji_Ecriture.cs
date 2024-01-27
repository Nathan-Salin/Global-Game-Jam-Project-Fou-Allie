using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Test_Emoji_Ecriture : MonoBehaviour
{   
    public TMP_Text m_Text;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Emoji.get_code_for_Emoji(Emoji.Name_of_Emoji.Magician_Hat));
        Debug.Log(Emoji.get_code_for_Emoji(Emoji.Name_of_Emoji.King));
        m_Text.text = "Test sprite <sprite name=" + Emoji.get_code_for_Emoji(Emoji.Name_of_Emoji.Magician_Hat)
                + "> et <sprite name=" + Emoji.get_code_for_Emoji(Emoji.Name_of_Emoji.King) + ">\n";
    }
}
