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
                        /*Si no llegó ninguno de los símbolos de arriba
                         *va a mandar al estado de error, ya que sólo se
                         *aceptan los de arriba
                         * */
                        state = "E";
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
                        state = "E";
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
                        state = "E";
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
                        state = "E";
                    }
                    break;

                case "F":

                    if (character.Equals('='))
                    {
                        Debug.Log("DT: Aquí debería ir al de pila 5");
                    }

                    else
                    { 
                        state = "E";
                    }
                    break;

                case "EC":
                    state = "RWVS2";
                    break;

                case "VAE":
                    Debug.Log("Vuelve al autómata principal");
                    AutomataController.instance.index = i - 1;
                    return AutomataType.MainStructure;

                case "RWVS2":
                    Debug.Log("Verifica variables con comas AVPR2");
                    AutomataController.instance.index = i;
                    return AutomataType.RW2VariableSyntax;

                case "VAP":
                    Debug.Log("Va al autómata de pila");
                    //Se pasa solo la i para no procesar el = 
                    AutomataController.instance.index = i;
                    return AutomataType.StackAutomata;

                case "E":
                    Debug.Log("Entró a error en DTVariableSyntax");
                    return AutomataType.Error;
            }
        }
        return AutomataType.Error;
    }
}
