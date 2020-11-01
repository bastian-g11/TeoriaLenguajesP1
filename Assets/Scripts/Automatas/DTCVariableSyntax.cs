using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DTCVariableSyntax : MonoBehaviour
{
    public AutomataType CheckDataTypeVariableSyntax(string lineToRead, int _index)
    {
        string line = lineToRead;
        string state = "IN";
        int index = _index;
        char character;
        string errors = null;

        for (int i = index; i < line.Length; i++)
        {
            character = line[i];
            Debug.Log("Estoy en DTC, en el estado: " + state);
            Debug.Log("Símbolo a procesar: " + character);

            if (character.Equals('{') || character.Equals('}')
                || character.Equals('(') || character.Equals(')')
                || character.Equals('[') || character.Equals(']')
                || character.Equals('<') || character.Equals('>'))
            {
                Debug.Log("Entró un símbolo que debemos ignorar en DTCVS");
                continue;
            }

            switch (state)
            {
                case "IN":

                    if (Char.IsLetterOrDigit(character))
                    {
                        state = "A";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "IN";
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                        InsertarSeparador(i, line);
                    }

                    else
                    {
                        Debug.Log("aaaaaaaaaaaaaaaaaaaasx: " + character + line[i - 1]);
                        errors = "- DTC1 El nombre de la variable empieza de manera incorrecta\n";
                    }
                    break;

                case "A":

                    if (Char.IsLetterOrDigit(character))
                    {
                        state = "A";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "A";
                    }

                    //else if (character.Equals('+') || character.Equals('-') ||
                    //   character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    //{
                    //    state = "F";
                    //    InsertarVariable(index, i - 1, line);
                    //    InsertarOperador(i, line);
                    //}

                    else if (character.Equals(','))
                    {
                        state = "EC";
                        InsertarVariable(index, i, line);
                        InsertarSeparador(i, line);
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                        InsertarVariable(index, i, line);
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                        InsertarVariable(index, i, line);
                        InsertarSeparador(i, line);
                    }

                    else
                    {
                        errors = "- DTC2 El nombre de la variable empieza de manera incorrecta\n";
                    }
                    break;

                case "D":

                    if (character.Equals('+') || character.Equals('-') ||
                       character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "F";

                    }

                    else if (character.Equals(','))
                    {
                        state = "EC";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "D";
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                    }

                    else
                    {
                        errors = "- DTC3 El nombre de la variable empieza de manera incorrecta\n";
                    }
                    break;

                case "SS":

                    //if (character.Equals('+') || character.Equals('-') ||
                    //    character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    //{
                    //    state = "F";
                    //}

                    if (character.Equals(','))
                    {
                        state = "EC";
                        InsertarSeparador(i, line);
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                        InsertarSeparador(i, line);

                    }

                    else
                    {
                        errors = "- DTC4 Expresión de declaración contiene símbolo inválido\n";
                    }
                    break;

                case "F":
                    if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                        InsertarSeparador(i, line);
                    }
                    else
                    {
                        errors = "- DTC5 Expresión de declaración contiene símbolo inválido\n";

                    }
                    break;

                case "EC":
                    state = "RWVS2";
                    break;

                case "VAE":
                    Debug.Log("Vuelve al autómata principal");

                    AutomataController.instance.index = i - 1;

                    //InsertarNodo(index, i, line);

                    if (errors != null)
                    {
                        ErrorController.instance.SetErrorMessage(errors);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.MainStructure;

                case "RWVS2":
                    Debug.Log("Verifica variables con comas AVPR2");
                    AutomataController.instance.index = i - 1;
                    
                    //if (line[i].Equals(','))
                    //{
                    //    InsertarNodo(index, i - 1, line);
                    //}
                    //else
                    //{
                    //    InsertarNodo(index, i, line);
                    //}


                    if (errors != null)
                    {
                        ErrorController.instance.SetErrorMessage(errors);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.RW2VariableSyntax;

                case "E":
                    Debug.Log("Entró a error en DTCCCVariableSyntax");
                    return AutomataType.Error;
            }
        }
        AutomataController.instance.index = line.Length - 1;

        if (state.Equals("IN"))
        {
            errors = errors + "- Expresión incompleta\n";
            ErrorController.instance.SetErrorMessage(errors);
            ErrorController.instance.SetLineHasError(true);
            return AutomataType.Error;
        }

        else if (state.Equals("VAE") || line[line.Length-1].Equals(';'))
        {
            if (errors != null)
            {
                ErrorController.instance.SetErrorMessage(errors);
                ErrorController.instance.SetLineHasError(true);
            }

            InsertarVariable(index, line.Length - 1, line);
            InsertarSeparador(line.Length, line);
            //InsertarNodo(index, line.Length - 1, line);
            return AutomataType.MainStructure;
        }

        errors = errors + "- Expresión incompleta\n";
        ErrorController.instance.SetErrorMessage(errors);
        ErrorController.instance.SetLineHasError(true);
        return AutomataType.Error;
    }

    public void InsertarNodo(int index, int i, string line)
    {
        int length = (i - 1) - index;
        string variable = line.Substring(index, length);
        SinglyLinkedListController.instance.AddNode("tipo", variable);
        Debug.Log("<color=green> Nodo: </color>" + variable);
        Debug.Log("<color=blue> Primer Nodo: </color>" + SinglyLinkedListController.instance.
            singlyLinkedList.GetFirstNode().GetValue());
        Debug.Log("<color=blue> Siguiente Nodo: </color>" + SinglyLinkedListController.instance.
            singlyLinkedList.GetFirstNode().GetNextNode());
        UIController.instance.CreateUINode();
    }

    public void InsertarVariable(int index, int i, string line)
    {
        int length = i - index;
        string variable = line.Substring(index, length);
        SinglyLinkedListController.instance.AddNode("Variable", variable);
        UIController.instance.CreateUINode();
    }

    public void InsertarSeparador(int i, string line)
    {
        string separador = line.Substring(i, 1);
        SinglyLinkedListController.instance.AddNode("Separador", separador);
        UIController.instance.CreateUINode();
    }
}
