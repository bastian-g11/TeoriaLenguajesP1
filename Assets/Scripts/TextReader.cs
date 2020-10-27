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
        if (instance != null)
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
        System.IO.StringReader strReader = new StringReader(lineaTexto);
        AutomataType nextAutomata = AutomataController.instance.nextAutomata;
        int index;

        aLine = strReader.ReadLine();
        bool canContinue = true;

        while (canContinue)
        {
            //Captura una línea
            index = AutomataController.instance.index;
            if(nextAutomata == AutomataType.Error || nextAutomata == AutomataType.None)
            {
                canContinue = false;
            }

            switch (nextAutomata)
            {
                case AutomataType.MainStructure:
                    nextAutomata = AutomataController.instance.StartMainStructure(aLine, index);
                    Debug.Log("Uno: " + nextAutomata);
                    break;

                case AutomataType.ReservedWord:
                    nextAutomata = AutomataController.instance.StartReserverdWord(aLine, index);
                    Debug.Log("Dos: " + nextAutomata);
                    break;

                case AutomataType.RWVariableSyntax:
                    nextAutomata = AutomataController.instance.StartRWVariableSyntax(aLine, index);
                    Debug.Log("Tres: " + nextAutomata);
                    break;

                case AutomataType.RW2VariableSyntax:
                    nextAutomata = AutomataController.instance.StartRWVariableSyntaxII(aLine, index);
                    Debug.Log("Cuatro: " + nextAutomata);
                    break;

                case AutomataType.VariableSyntax:
                    nextAutomata = AutomataController.instance.StartVariableSyntax(aLine, index);
                    Debug.Log("Cinco: " + nextAutomata);
                    break;

                case AutomataType.DTVariableSyntax:
                    nextAutomata = AutomataController.instance.StartDTVariableSyntax(aLine, index);
                    Debug.Log("Seis: " + nextAutomata);
                    break;

                case AutomataType.DTCVariableSyntax:
                    nextAutomata = AutomataController.instance.StartDTCVariableSyntax(aLine, index);
                    Debug.Log("Siete: " + nextAutomata);
                    break;

                case AutomataType.StackAutomata:
                    nextAutomata = AutomataController.instance.StartStackAutomata(aLine, index);
                    Debug.Log("Ocho: " + nextAutomata);
                    break;

                case AutomataType.Error:
                    Debug.Log("Llegó a error en TextReader");
                    break;

                case AutomataType.None:
                    Debug.Log("Ningún autómata, debería aceptarse la línea (?");
                    break;

                default:
                    Debug.Log("Default case de TextReader");
                    break;
            }
        }
    }
}
