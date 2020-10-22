using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextReader : MonoBehaviour
{
    public Text txt;
    public string lineaTexto;

    #region singleton
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
    #endregion

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
        Automata automata = new Automata();

        //Descomentar para que lea todas las líneas
        //while (true)
        //{
            //Captura una línea
            aLine = strReader.ReadLine();
            if (aLine != null)
            {
                aParagraph = aParagraph + aLine + " ";

                //Mandar un cero siempre aquí??
                automata.StructureReader(aLine, 0);



                //Debug.Log("Linea: " + aLine);
            }
            else
            {
                aParagraph = aParagraph + "\n";
                //break;
            }
        //}
    }
}
