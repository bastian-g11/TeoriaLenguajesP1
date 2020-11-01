using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DTVariableSyntax : MonoBehaviour
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
            Debug.Log("Estoy en DT, en el estado: " + state);
            Debug.Log("Símbolo a procesar: " + character);

            if (character.Equals('{') || character.Equals('}')
                || character.Equals('(') || character.Equals(')')
                || character.Equals('[') || character.Equals(']')
                || character.Equals('<') || character.Equals('>'))
            {
                Debug.Log("Entró un símbolo que debemos ignorar en DTVS");
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
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 1");
                        state = "VAP";
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        Debug.Log("El nombre de la variable empieza de manera incorrecta");
                        errors = "- El nombre de la variable empieza de manera incorrecta\n";
                        //state = "E";
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

                    else if (character.Equals('+') || character.Equals('-') ||
                       character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "F";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals(','))
                    {
                        state = "EC";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);
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
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 2");
                        state = "VAP";
                        InsertarVariable(index, i - 1, line);
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        errors = "- El nombre de la variable empieza de manera incorrecta\n";
                        //state = "E";
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

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 3");
                        state = "VAP";
                    }

                    else
                    {
                        errors = "- El nombre de la variable empieza de manera incorrecta\n";
                        //state = "E";
                    }
                    break;

                case "SS":

                    if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "F";
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals(','))
                    {
                        state = "EC";
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 4");
                        state = "VAP";
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        errors = "- El nombre de la variable es incorrecto\n";
                        //state = "E";
                    }
                    break;

                case "F":

                    if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 5");
                        state = "VAP";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);

                    }

                    else
                    {
                        errors = "- El nombre de la variable es incorrecto\n";
                        //state = "E";
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

                    //InsertarNodo(index, i - 1, line);

                    if (errors != null)
                    {
                        ErrorController.instance.SetErrorMessage(errors);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.RW2VariableSyntax;

                case "VAP":
                    Debug.Log("Va al autómata de pila");

                    //InsertarNodo(index,  i,  line);

                    //Se pasa solo la i para no procesar el = 
                    AutomataController.instance.index = i;
                    if (errors != null)
                    {
                        ErrorController.instance.SetErrorMessage(errors);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.StackAutomata;

                case "E":
                    Debug.Log("Entró a error en DTVariableSyntax");
                    //return AutomataType.Error;
                    break;
            }
        }

        AutomataController.instance.index = line.Length;
        if (state.Equals("VAE") || line[line.Length - 1].Equals(';'))
        {
            if (errors != null)
            {
                ErrorController.instance.SetErrorMessage(errors);
                ErrorController.instance.SetLineHasError(true);
            }

            //InsertarNodo(index, line.Length, line);
            return AutomataType.MainStructure;
        }

        errors = errors + "- Falta punto y coma (;) \n";
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

    public void InsertarOperador(int i, string line)
    {
        string operador = line.Substring(i, 1);
        SinglyLinkedListController.instance.AddNode("Operador", operador);
        UIController.instance.CreateUINode();
    }
}
