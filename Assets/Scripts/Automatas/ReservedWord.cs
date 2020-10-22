using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReservedWord : Automata
{
    public void FindReservedWord(string lineToRead, int _index)
    {
        string line = lineToRead;
        string state = "IN";
        int index = _index;
        bool isGone = false;

        VariableSyntax vs = new VariableSyntax();

        for (int i = index; i < line.Length; i++)
        {
            if (isGone) return;

            char character = line[i];
            Debug.Log(character);
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
                    else if (Char.IsLetter(character))
                    {
                        Debug.Log("IN Resultó ser variable, vamos a revisarlo");
                        isGone = true;
                        vs.StartAutomata(i);
                        vs.VariableSyntaxChecker(line, vs.index);
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        vs.StartAutomata(i);
                        vs.VariableSyntaxChecker(line, vs.index);

                    }

                    else if (character.Equals(' '))
                    {
                        state = "IN";
                    }
 
                    else if (Char.IsDigit(character))
                    {
                        Debug.Log("ADSDAS");
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
                        vs.StartAutomata(i);
                        vs.VariableSyntaxChecker(line, vs.index);

                    }

                    else if (character.Equals('='))
                    {
                        vs.StartAutomata(i);
                        vs.VariableSyntaxChecker(line, vs.index);

                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/'))
                    {
                        vs.VariableSyntaxChecker(line, vs.index);

                    }

                    else if (character.Equals(' '))
                    {
                        vs.StartAutomata(i);
                        vs.VariableSyntaxChecker(line, vs.index);
                    }

                    else if (Char.IsDigit(character))
                    {
                        vs.StartAutomata(i);
                        vs.VariableSyntaxChecker(line, vs.index);
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
}
