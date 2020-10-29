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
        string error = null;
        bool hasError = false;
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
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 1");
                        state = "VAE";
                    }

                    else
                    {
                        Debug.Log("El nombre de la variable empieza de manera incorrecta");
                        if (!hasError)
                        {
                            error = "- El nombre de la variable empieza de manera incorrecta\n";
                        }
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
                    }

                    else if (character.Equals(','))
                    {
                        state = "EC";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 2");
                        state = "VAE";
                    }

                    else
                    {
                        if (!hasError)
                        {
                            error = "- El nombre de la variable empieza de manera incorrecta\n";
                        }
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
                        state = "VAE";
                    }

                    else
                    {
                        if (!hasError)
                        {
                            error = "- El nombre de la variable empieza de manera incorrecta\n";
                        }
                        //state = "E";
                    }
                    break;

                case "SS":

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
                        state = "SS";
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Vuelve al automata principal");
                        state = "VAE";
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 4");
                        state = "VAP";
                    }

                    else
                    {
                        if (!hasError)
                        {
                            error = "- El nombre de la variable empieza de manera incorrecta\n";
                        }
                        //state = "E";
                    }
                    break;

                case "F":

                    if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 5");
                    }

                    else
                    {
                        if (!hasError)
                        {
                            error = "- El nombre de la variable empieza de manera incorrecta\n";
                        }
                        //state = "E";
                    }
                    break;

                case "EC":
                    state = "RWVS2";
                    break;

                case "VAE":
                    Debug.Log("Vuelve al autómata principal");
                    AutomataController.instance.index = i - 1;
                    if (error != null)
                    {
                        ErrorController.instance.SetErrorMessage(error);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.MainStructure;

                case "RWVS2":
                    Debug.Log("Verifica variables con comas AVPR2");
                    AutomataController.instance.index = i;
                    if (error != null)
                    {
                        ErrorController.instance.SetErrorMessage(error);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.RW2VariableSyntax;

                case "VAP":
                    Debug.Log("Va al autómata de pila");
                    //Se pasa solo la i para no procesar el = 
                    AutomataController.instance.index = i;
                    if (error != null)
                    {
                        ErrorController.instance.SetErrorMessage(error);
                        ErrorController.instance.SetLineHasError(true);
                    }
                    return AutomataType.StackAutomata;

                case "E":
                    Debug.Log("Entró a error en DTVariableSyntax");
                    //return AutomataType.Error;
                    break;
            }
        }
        if (state.Equals("VAE"))
        {
            AutomataController.instance.index = line.Length - 1;
            if (error != null)
            {
                ErrorController.instance.SetErrorMessage(error);
                ErrorController.instance.SetLineHasError(true);
            }
            return AutomataType.MainStructure;
        }
        return AutomataType.Error;
    }
}
