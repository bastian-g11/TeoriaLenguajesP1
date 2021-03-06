﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextReader : MonoBehaviour
{
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

    public void SetLinkedList()
    {
        SinglyLinkedListController.instance.CreateSinglyLinkedList();
    }

    public void AddNode(string _dataType, string _value)
    {
        SinglyLinkedListController.instance.AddNode(_dataType, _value);
    }

    public void ResetLinkedList()
    {
        SinglyLinkedListController.instance.ResetSinglyLinkedList();
    }

    public void Recorrer(string _lineToRead)
    {
        string aLine = null;
        string lineToRead = _lineToRead;
        int index;
        int lineNumber = 0;
        bool canContinue = true;
        bool lineHasError;
        System.IO.StringReader strReader = new StringReader(lineToRead);

        //Aquí podría asignarse directamente el tipo de autómata?
        //AutomataType nextAutomata = AutomataController.instance.nextAutomata;
        AutomataType nextAutomata = AutomataType.MainStructure;

        
        while(true)
        {
            //Reinicio todo
            aLine = strReader.ReadLine();
            if (aLine == null) break;

            AutomataController.instance.index = 0;
            nextAutomata = AutomataType.MainStructure;
            canContinue = true;
            lineNumber += 1;
            SetLinkedList();
            AutomataController.instance.exp = "";
            UIController.instance.CreateContainer();
            Debug.Log(aLine);
            Debug.Log("*************************************************");
            
            while (canContinue)
            {
                //Captura una línea
                index = AutomataController.instance.index;
                if (nextAutomata == AutomataType.Error || nextAutomata == AutomataType.None)
                {
                    canContinue = false;
                }

                switch (nextAutomata)
                {
                    case AutomataType.MainStructure:
                        nextAutomata = AutomataController.instance.StartMainStructure(aLine, index);
                        break;

                    case AutomataType.ReservedWord:
                        nextAutomata = AutomataController.instance.StartReserverdWord(aLine, index);
                        break;

                    case AutomataType.RWVariableSyntax:
                        nextAutomata = AutomataController.instance.StartRWVariableSyntax(aLine, index);
                        break;

                    case AutomataType.RW2VariableSyntax:
                        nextAutomata = AutomataController.instance.StartRWVariableSyntaxII(aLine, index);
                        break;

                    case AutomataType.VariableSyntax:
                        nextAutomata = AutomataController.instance.StartVariableSyntax(aLine, index);
                        break;

                    case AutomataType.DTVariableSyntax:
                        nextAutomata = AutomataController.instance.StartDTVariableSyntax(aLine, index);
                        break;

                    case AutomataType.DTCVariableSyntax:
                        nextAutomata = AutomataController.instance.StartDTCVariableSyntax(aLine, index);
                        break;

                    case AutomataType.StackAutomata:
                        nextAutomata = AutomataController.instance.StartStackAutomata(aLine, index);
                        break;

                    case AutomataType.Error:
                        break;

                    case AutomataType.None:
                        break;

                    default:
                        break;
                }
            }

            lineHasError = ErrorController.instance.GetLineHasError();
            UIController.instance.SetErrorText(lineNumber);
            if (lineHasError)
            {
                Destroy(UIController.instance.listContainer);
                UIController.instance.distanceY = UIController.instance.distanceY - 5;
                ResetLinkedList();
            }
        }

    }
}
