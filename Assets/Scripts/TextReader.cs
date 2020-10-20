using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextReader : MonoBehaviour
{
    public Text txt;
    public string lineaTexto;
    public static TextReader instance;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText()
    {
        lineaTexto = txt.text;
        Debug.Log(lineaTexto);
        Recorrer();
    }
    
    public void Recorrer()
    {
        //Una línea
        string aLine = null;
        //Todas las líneas
        string aParagraph = null;
        System.IO.StringReader strReader = new StringReader(lineaTexto);
        while (true)
        {
            //Captua una línea
            aLine = strReader.ReadLine();
            if (aLine != null)
            {
                aParagraph = aParagraph + aLine + " ";
                //Autómata Estructura
                Debug.Log("Linea: " + aLine);
            }
            else
            {
                aParagraph = aParagraph + "\n";
                break;
            }
        }
    }
}
