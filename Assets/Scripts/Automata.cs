using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Automata
{
    public string line;
    
    public void StructureReader(string lineToRead, int _index)
    {
        line = lineToRead;
        string state = " ";
        int index = _index;

        for (int i = index; i < line.Length; i++)
        {
            char character = line[i];

            if (state.Equals('E'))
            {
                Debug.Log("ERROR");
                break;
            }

            if (Char.IsLetter(character))
            {
                ReservedWord(i);
                break;
            }
            else if(Char.IsDigit(character))
            {
                state = "E";
            }
        }
    }

    public void ReservedWord(int _index)
    {
        string state = "IN";
        int index = _index;
        bool isGone = false;

        for (int i = index; i < line.Length; i++)
        {
            if (isGone) return;
            
            char character = line[i];
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

                    /*Si no es ninguno de las letras de arriba
                     *entonces todas las demás letras van a 
                     * mandar al otro autómata
                     * */
                    else if(Char.IsLetter(character))
                    {
                        Debug.Log("IN Resultó ser variable, vamos a revisarlo");
                        isGone = true;
                        VariableSyntaxChecker(i);
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        VariableSyntaxChecker(i);
                    }

                    else if (character.Equals(' '))
                    {
                        state = "IN";
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
                        Debug.Log("I12 Resultó ser variable, vamos a revisarlo");
                        Debug.Log("casdad: " + i);
                        isGone = true;
                        VariableSyntaxChecker(i);

                    }

                    else if (character.Equals('='))
                    {
                        VariableSyntaxChecker(i);
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        VariableSyntaxChecker(i);
                    }

                    else if (character.Equals(' '))
                    {
                        VariableSyntaxChecker(i);
                    }

                    else if (Char.IsDigit(character))
                    {
                        VariableSyntaxChecker(i);
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
                    break;

                case "T1":
                    break;

                case "F1":
                    break;

                case "L1":
                    break;

                case "O1":
                    break;

                case "A1":
                    break;

                case "T2":
                    break;

                case "F2":
                    break;

                case "B1":
                    break;

                case "O2":
                    break;

                case "O3":
                    break;

                case "L2":
                    break;

                case "E1":
                    break;

                case "L3":
                    break;

                case "S1":
                    break;

                case "E2":
                    break;

                case "S2":
                    break;

                case "T3":
                    break;

                case "R1":
                    break;

                case "I3":
                    break;

                case "N2":
                    break;

                case "G":
                    break;

                case "C":
                    break;

                case "H":
                    break;

                case "A2":
                    break;

                case "R":
                    break;

                case "D":
                    break;

                case "O4":
                    break;

                case "U":
                    break;

                case "B2":
                    break;

                case "L4":
                    break;

                case "E3":
                    break;

                default:
                    Debug.Log("Algo raro pasa");
                    break;
            }
        }
    }

    public void VariableSyntaxChecker(int _index)
    {
        string state = "IN";
        int index = _index;
        Debug.Log("VSC, empezamos desde: " + index);
        Debug.Log("VSC, empezamos desde: " + line[index]);

        for (int i = index; i < line.Length; i++)
        {
            char character = line[i];
            if (state.Equals("E"))
            {
                Debug.Log("Se entró a estado de error");
                //Cortar el ciclo para no seguir evaluando
                break;
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
                        state = "FF";
                    }

                    else if(character.Equals(' '))
                    {
                        state = "SS";
                    }

                    else if (character.Equals('='))
                    {
                        //Lo manda al autómata de pila
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

                case "E":
                    Debug.Log("Error en la línea");
                    state = "E";
                    break;
            }
        }
    }
}
