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

        for (int i = index; i < line.Length; i++)
        {
           character = line[i];
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
                        state = "FF";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                        Debug.Log("AAA");
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("Aquí debería ir al de pila 1");
                        state = "VAP";
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

                    else if (character.Equals('+') || character.Equals('-') ||
                       character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "F";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "SS";
                    }

                    else if (character.Equals('='))
                    {
                        Debug.Log("Aquí debería ir al de pila 2");
                        state = "VAP";
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

                case "SS":
                    Debug.Log("Entró a SS");
                    if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        state = "F";
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
                    }

                    else
                    {
                        /*Si no llegó ninguno de los símbolos de arriba
                         *va a mandar al estado de error, ya que sólo se
                         *aceptan los de arriba
                         * */
                        Debug.Log("Entró a error, con este símbolo: " + character);
                        state = "E";
                    }
                    break;

                case "F":
                    if (character.Equals('='))
                    {
                        //Lo manda al autómata de pila
                        Debug.Log("Aquí debería ir al de pila 4");
                        state = "VAP";
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

                case "VAP":

                    //Se pasa solo la i para no procesar el = 
                    AutomataController.instance.index = i ;
                    return AutomataType.StackAutomata;

                case "E":
                    Debug.Log("Entró a error en VariableSyntax");
                    return AutomataType.Error;
            }
        }
        return AutomataType.Error;
    }
}
