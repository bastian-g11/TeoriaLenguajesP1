using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReservedWord
{
    public AutomataType FindReservedWord(string lineToRead, int _index)
    {
        string line = lineToRead;
        string state = "IN";
        int index = _index;

        for (int i = index; i < line.Length; i++)
        {
            char character = line[i];
            Debug.Log("Símbolo a procesar: " + character);
            switch (state)
            {
                case "IN":
                    if (character.Equals('i'))
                    {
                        state = "I12";
                        Debug.Log("ESTOY EN EL ESTADO I12");
                    }

                    else if (character.Equals('f'))
                    {
                        state = "F1";
                        Debug.Log("ESTOY EN EL ESTADO F1");
                    }

                    else if (character.Equals('e'))
                    {
                        state = "E1";
                        Debug.Log("ESTOY EN EL ESTADO E1");
                    }

                    else if (character.Equals('S'))
                    {
                        state = "S2";
                        Debug.Log("ESTOY EN EL ESTADO S2");
                    }

                    else if (character.Equals('b'))
                    {
                        state = "B1";
                        Debug.Log("ESTOY EN EL ESTADO B1");
                    }

                    else if (character.Equals('c'))
                    {
                        state = "C";
                        Debug.Log("ESTOY EN EL ESTADO C");
                    }

                    else if (character.Equals('d'))
                    {
                        state = "D";
                        Debug.Log("ESTOY EN EL ESTADO D");
                    }

                    else if (character.Equals(' '))
                    {
                        state = "IN";
                    }

                    /*Si no es ninguno de las letras de arriba
                     *entonces todas las demás letras van a 
                     * mandar al otro autómata
                     * */
                    else if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        state = "EV";

                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "E";
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

                case "I12":
                    if (character.Equals('n'))
                    {
                        state = "N1";
                        Debug.Log("ESTOY EN EL ESTADO N1");
                    }

                    else if (character.Equals('f'))
                    {
                        state = "F2";
                        Debug.Log("ESTOY EN EL ESTADO F2");
                    }

                    /*Si no es ninguno de las letras de arriba
                     *entonces todas las demás letras van a 
                     * mandar al otro autómata
                     * */
                    else if (Char.IsLetter(character))
                    {

                        state = "EV";

                    }

                    else if (character.Equals('='))
                    {
                        state = "EV";

                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
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

                case "N1":
                    if (character.Equals('t'))
                    {
                        state = "T1";
                        Debug.Log("ESTOY EN EL ESTADO T1");
                    }
                    break;

                case "T1":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }


                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    } 
                    
                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        state = "E";
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


                case "EV":
                    Debug.Log("Es una variable");
                    AutomataController.instance.index = i;
                    return AutomataType.VariableSyntax;

                case "EVTP":
                    Debug.Log("Es una variable con tipo de dato");
                    AutomataController.instance.index = i;
                    return AutomataType.VariableSyntax;

                case "E":
                    Debug.Log("Entró a error en ReservedWord");
                    return AutomataType.Error;

                default:
                    Debug.Log("Algo raro pasa");
                    break;
            }
        }
        return AutomataType.None;
    }
}
