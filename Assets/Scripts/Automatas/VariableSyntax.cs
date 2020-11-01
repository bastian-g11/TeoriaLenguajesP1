using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VariableSyntax 
{
    public AutomataType CheckVariableSyntax(string lineToRead, int _index)
    {
        string line = lineToRead;
        string state = "IN";
        int index = _index;
        char character;
        string errors = null;

        for (int i = index; i < line.Length; i++)
        {
            character = line[i];
            Debug.Log("Estoy en VS, en el estado: " + state);
            Debug.Log("Símbolo a procesar: " + character);

            if (character.Equals('{') || character.Equals('}')
                || character.Equals('(') || character.Equals(')')
                || character.Equals('[') || character.Equals(']')
                || character.Equals('<') || character.Equals('>'))
            {
                Debug.Log("Entró un símbolo que debemos ignorar en VS");
                continue;
            }

            switch (state)
            {
                case "IN":
                    if (Char.IsLetterOrDigit(character))
                    {
                        Debug.Log("VSC, estoy leyendo una letra o #");
                        state = "A";
                    }

                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        state = "F";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("Aquí debería ir al de pila 1");
                        state = "VAP";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        errors = "- Error en nombramiento de variable\n";
                        //state = "E";
                    }
                    break;

                case "A":
                    if (Char.IsLetterOrDigit(character))
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

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                        InsertarVariable(index, i, line);
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("Aquí debería ir al de pila 2");
                        state = "VAP";
                        InsertarVariable(index, i, line);
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        errors = "- Error en nombramiento de variable\n";
                    }
                    break;

                case "SS":
                    Debug.Log("Entró a SS");
                    if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        state = "F";
                        InsertarOperador(i, line);
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                    }

                    else if (character.Equals('='))
                    {
                        //Lo manda al autómata de pila
                        Debug.Log("2. Aquí debería ir al de pila 3");
                        state = "VAP";
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        errors = "- Error en nombramiento de variable\n";

                        //state = "E";
                    }
                    break;

                case "F":
                    if (character.Equals('='))
                    {
                        //Lo manda al autómata de pila
                        Debug.Log("Aquí debería ir al de pila 4");
                        state = "VAP";
                        InsertarOperador(i, line);
                    }

                    else
                    {
                        errors = "- Error en nombramiento de variable\n";
                        //state = "E";
                    }
                    break;

                case "VAP":

                    //Se pasa solo la i para no procesar el = 

                    AutomataController.instance.index = i;
                    if (errors != null)
                    {
                        ErrorController.instance.SetErrorMessage(errors);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.StackAutomata;

                case "E":
                    Debug.Log("Entró a error en VariableSyntax");
                    return AutomataType.Error;
            }
        }

        errors = errors + "- Expresión incompleta\n";
        ErrorController.instance.SetErrorMessage(errors);
        ErrorController.instance.SetLineHasError(true);
        return AutomataType.Error;
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
