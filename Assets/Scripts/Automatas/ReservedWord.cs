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
        char character;

        for (int i = index; i < line.Length; i++)
        {
            character = line[i];
            Debug.Log("Estoy en RW, en el estado: " + state);
            Debug.Log("Símbolo a procesar: " + character);
            if (character.Equals('{') || character.Equals('}')
                || character.Equals('(') || character.Equals(')')
                || character.Equals('[') || character.Equals(']')
                || character.Equals('<') || character.Equals('>'))
            {
                Debug.Log("Entró un símbolo que debemos ignorar en RW");
                continue;
            }

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
                        Debug.Log("La i va en: " + i);
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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

                case "T1":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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

                case "F1":

                    if (character.Equals('l'))
                    {
                        state = "L1";
                        Debug.Log("ESTOY EN EL ESTADO L1");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }

                    break;

                case "L1":
                    if (character.Equals('o'))
                    {
                        state = "O1";
                        Debug.Log("ESTOY EN EL ESTADO O1");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "O1":

                    if (character.Equals('a'))
                    {
                        state = "A1";
                        Debug.Log("ESTOY EN EL ESTADO A1");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "A1":

                    if (character.Equals('t'))
                    {
                        state = "T2";
                        Debug.Log("ESTOY EN EL ESTADO T2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "T2":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "E";
                    }

                    else
                    {
                        state = "E";
                    }
                    break;

                case "F2":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "E";
                    }

                    else
                    {
                        state = "E";
                    }
                    break;

                case "B1":

                    if (character.Equals('o'))
                    {
                        state = "O2";
                        Debug.Log("ESTOY EN EL ESTADO O2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "O2":

                    if (character.Equals('o'))
                    {
                        state = "O3";
                        Debug.Log("ESTOY EN EL ESTADO O3");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "O3":

                    if (character.Equals('l'))
                    {
                        state = "L2";
                        Debug.Log("ESTOY EN EL ESTADO L2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "L2":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "E";
                    }

                    else
                    {
                        state = "E";
                    }
                    break;

                case "E1":

                    if (character.Equals('l'))
                    {
                        state = "L3";
                        Debug.Log("ESTOY EN EL ESTADO L3");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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

                        state = "E";
                    }
                    break;

                case "L3":

                    if (character.Equals('s'))
                    {
                        state = "S1";
                        Debug.Log("ESTOY EN EL ESTADO S1");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "S1":

                    if (character.Equals('e'))
                    {
                        state = "E2";
                        Debug.Log("ESTOY EN EL ESTADO E2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "E2":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "E";
                    }

                    else
                    {
                        state = "E";
                    }
                    break;

                case "S2":

                    if (character.Equals('t'))
                    {
                        state = "T3";
                        Debug.Log("ESTOY EN EL ESTADO T3");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "T3":

                    if (character.Equals('r'))
                    {
                        state = "R1";
                        Debug.Log("ESTOY EN EL ESTADO R1");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "R1":

                    if (character.Equals('i'))
                    {
                        state = "I3";
                        Debug.Log("ESTOY EN EL ESTADO I3");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "I3":

                    if (character.Equals('n'))
                    {
                        state = "N2";
                        Debug.Log("ESTOY EN EL ESTADO N2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "N2":

                    if (character.Equals('g'))
                    {
                        state = "G";
                        Debug.Log("ESTOY EN EL ESTADO G");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "G":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "E";
                    }

                    else
                    {
                        state = "E";
                    }
                    break;

                case "C":

                    if (character.Equals('h'))
                    {
                        state = "H";
                        Debug.Log("ESTOY EN EL ESTADO H");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "H":

                    if (character.Equals('a'))
                    {
                        state = "A2";
                        Debug.Log("ESTOY EN EL ESTADO A2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "A2":

                    if (character.Equals('r'))
                    {
                        state = "R";
                        Debug.Log("ESTOY EN EL ESTADO R");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "R2":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        state = "E";
                    }

                    else
                    {
                        state = "E";
                    }

                    break;

                case "D":

                    if (character.Equals('o'))
                    {
                        state = "O4";
                        Debug.Log("ESTOY EN EL ESTADO A1");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "O4":

                    if (character.Equals('u'))
                    {
                        state = "U";
                        Debug.Log("ESTOY EN EL ESTADO U");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "U":

                    if (character.Equals('b'))
                    {
                        state = "B2";
                        Debug.Log("ESTOY EN EL ESTADO B2");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "B2":

                    if (character.Equals('l'))
                    {
                        state = "L4";
                        Debug.Log("ESTOY EN EL ESTADO L4");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "L4":

                    if (character.Equals('e'))
                    {
                        state = "E3";
                        Debug.Log("ESTOY EN EL ESTADO E3");
                    }

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
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                        state = "E";
                    }
                    break;

                case "E3":

                    if (Char.IsLetter(character))
                    {
                        state = "EV";
                    }

                    else if (Char.IsDigit(character))
                    {
                        state = "EV";
                    }

                    else if (character.Equals(' '))
                    {
                        state = "EVTP";
                    }

                    //Operadores finales
                    else if (character.Equals('+') || character.Equals('-') ||
                        character.Equals('*') || character.Equals('/') || character.Equals('%'))
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
                    //Insertar creación de nodo ??
                    AutomataController.instance.index = i;
                    return AutomataType.VariableSyntax;

                case "EVTP":
                    Debug.Log("Es una variable con tipo de dato");
                    //Insertar creación de nodo ??
                    AutomataController.instance.index = i;
                    return AutomataType.DTVariableSyntax;

                case "E":
                    Debug.Log("Entró a error en ReservedWord");
                    //Instar eliminación de lista ??
                    return AutomataType.Error;

                default:
                    Debug.Log("Algo raro pasa");
                    break;
            }
        }
        //Debería ser error o None?
        return AutomataType.Error;
    }
}
