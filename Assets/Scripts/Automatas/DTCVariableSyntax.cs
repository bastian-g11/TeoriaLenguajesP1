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

        for (int i = index; i < line.Length; i++)
        {
            character = line[i];
            Debug.Log("Estoy en DTC, en el estado: " + state);
            Debug.Log("Símbolo a procesar: " + character);
            switch (state)
            {
                case "IN":

                    if (Char.IsLetterOrDigit(character))
                    {
                        state = "A";
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

                    else
                    {
                        state = "E";
                    }
                    break;

                case "F":
                    state = "E";
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

                case "E":
                    Debug.Log("Entró a error en DTCCCVariableSyntax");
                    return AutomataType.Error;
            }
        }
        return AutomataType.None;
    }
}
