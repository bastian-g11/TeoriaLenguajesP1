using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StackAutomata
{
    Stack stack = new Stack();

    public AutomataType CheckRightSideStructure(string lineToRead, int _index)
    {
        string line = lineToRead;
        int index = _index;
        string symbol;
        char character;

        stack.Clear();
        stack.Push("T"); //Triangulo de pila vacía
        stack.Push("C");

        for (int i = index; i < line.Length; i++)
        {
            character = line[i];
            symbol = (string)stack.Peek();

            Debug.Log("Símbolo en TOPE de pila: " + (string)stack.Peek());
            Debug.Log("Símbolo a procesar: " + character);

            if (character.Equals('{') || character.Equals('}')
                || character.Equals('(') || character.Equals(')')
                || character.Equals('[') || character.Equals(']'))
            {
                Debug.Log("Entró un símbolo que debemos ignorar en VS");
                continue;
            }

            switch (symbol)
            {
                case "C":
                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_'))
                    {
                        Replace("V");
                    }

                    else if (Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('"'))
                    {
                        Replace("CM");
                    }

                    else if (character.Equals('+') || character.Equals('-')) 
                    {
                        Replace("-");
                    }

                    else if (character.Equals(' '))
                    {
                        Debug.Log("Entró un espacio en el de pila");
                    }

                    else
                    {
                        Debug.Log("Error 1 ");
                        Replace("ER");
                    }
                    break;

                case "W":

                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_'))
                    {
                        Replace("V");
                    }

                    else if (Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('"'))
                    {
                        Replace("CM");
                    }

                    else if (character.Equals('+') || character.Equals('-'))
                    {
                        Replace("-");
                    }

                    else if (character.Equals(' '))
                    {
                        Debug.Log("Entró un espacio en el de pila");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case "T":

                    if (character.Equals('+'))
                    {
                        Replace("+");
                    }

                    else if (character.Equals('-'))
                    {
                        Replace("-");
                    }

                    else if (character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        Replace("S");
                    }

                    else if (character.Equals('<') || character.Equals('>') || character.Equals('!'))
                    {
                        Replace("B");
                    }

                    else if (character.Equals('='))
                    {
                        Replace("=");
                    }

                    else if (character.Equals('|'))
                    {
                        Replace("|");
                    }

                    else if (character.Equals('&'))
                    {
                        Replace("&");
                    }

                    else if (character.Equals(' '))
                    {
                        Debug.Log("Entró espacio en el de pila");
                    }

                    else if (character.Equals(';'))
                    {
                        Replace("VAE");
                    }

                    else
                    {
                        Replace("ER");

                    }
                    break;

                case "K":

                    if (character.Equals('+'))
                    {
                        Replace("+");
                    }

                    else if (character.Equals('-'))
                    {
                        Replace("-");
                    }

                    else if (character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        Replace("S");
                    }

                    else if (character.Equals('<') || character.Equals('>') || character.Equals('!'))
                    {
                        Replace("B");
                    }

                    else if (character.Equals('='))
                    {
                        Replace("=");
                    }

                    else if (character.Equals('|'))
                    {
                        Replace("|");
                    }

                    else if (character.Equals('&'))
                    {
                        Replace("&");
                    }

                    else if (character.Equals(';'))
                    {
                        Replace("VAE");
                    }

                    else if (character.Equals(' '))
                    {
                        Debug.Log("Entró espacio en el de pila");
                    }

                    else
                    {
                        Replace("ER");

                    }
                    break;

                case "V":

                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_')
                        || Char.IsDigit(character))
                    {
                        Debug.Log("Avance en V");
                    }

                    else if (character.Equals('+'))
                    {
                        Replace("+");
                    }

                    else if (character.Equals('-'))
                    {
                        Replace("-");
                    }

                    else if (character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        Replace("S");
                    }

                    else if (character.Equals('<') || character.Equals('>') || character.Equals('!'))
                    {
                        Replace("B");
                    }

                    else if (character.Equals('='))
                    {
                        Replace("=");
                    }

                    else if (character.Equals('|'))
                    {
                        Replace("|");
                    }

                    else if (character.Equals('&'))
                    {
                        Replace("&");
                    }

                    else if (character.Equals(';'))
                    {
                        Replace("VAE");
                    }

                    else
                    {
                        Replace("ER");
                    }
                        break;

                case "N":

                    if (Char.IsDigit(character))
                    {
                        Debug.Log("Avance en N");
                    }

                    else if (character.Equals('+'))
                    {
                        Replace("+");
                    }

                    else if (character.Equals('-'))
                    {
                        Replace("-");
                    }

                    else if (character.Equals('.'))
                    {
                        Replace(".");
                    }

                    else if (character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        Replace("S");
                    }

                    else if (character.Equals('<') || character.Equals('>') || character.Equals('!'))
                    {
                        Replace("B");
                    }

                    else if (character.Equals('='))
                    {
                        Replace("=");
                    }

                    else if (character.Equals('|'))
                    {
                        Replace("|");
                    }

                    else if (character.Equals('&'))
                    {
                        Replace("&");
                    }

                    else if (character.Equals(' '))
                    {
                        Replace("K");
                        Debug.Log("Entró espacio en el de pila, después de un #");
                    }

                    else if (character.Equals('E') || character.Equals('e'))
                    {
                        Replace("E");
                    }

                    else if (character.Equals(';'))
                    {
                        Debug.Log("Simbolo: "+character);
                        Debug.Log("índice: "+i);
                        Replace("VAE");
                    }

                    else
                    {
                        Replace("ER");
                    }

                    break;

                case "CM":

                    if(character.Equals('"'))
                    {
                        stack.Pop();
                    }

                    break;

                case "S":

                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_'))
                    {
                        Replace("V");
                    }

                    else if (Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('"'))
                    {
                        Replace("CM");
                    }

                    else if (character.Equals('.'))
                    {
                        Replace(".");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case ".":

                    if (Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('E') || character.Equals('e'))
                    {
                        Replace("E");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case "+":

                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_'))
                    {
                        Replace("V");
                    }
                    
                    else if(Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('"'))
                    {
                        Replace("CM");
                    }

                    else if (character.Equals('.'))
                    {
                        Replace(".");
                    }

                    else if (character.Equals(' '))
                    {
                        Debug.Log("Entró espacio en el de pila");
                    }

                    else
                    {
                        Replace("ER");
                    }

                    break;

                case "-":

                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_'))
                    {
                        Replace("V");
                    }

                    else if(Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('.'))
                    {
                        Replace(".");
                    }

                    else if (character.Equals(' '))
                    {
                        Debug.Log("Entró espacio en el de pila");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case "B":

                    if (Char.IsLetter(character) || character.Equals('$') || character.Equals('_'))
                    {
                        Replace("V");
                    }

                    else if (Char.IsDigit(character))
                    {
                        Replace("N");
                    }

                    else if (character.Equals('='))
                    {
                        Replace("W");
                    }

                    else
                    {
                        Replace("ER");
                    }

                    break;

                case "=":

                    if (character.Equals('='))
                    {
                        Replace("W");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case "&":

                    if (character.Equals('&'))
                    {
                        Replace("W");
                    }

                    else
                    {
                        Replace("ER");
                    }

                    break;

                case "|":

                    if (character.Equals('|'))
                    {
                        Replace("W");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case "E":

                    if(char.IsDigit(character))
                    {
                        Replace("Z");
                    }

                    else if (character.Equals('+'))
                    {
                        Replace("Y");
                    }

                    else if (character.Equals('-'))
                    {
                        Replace("Y");
                    }

                    else
                    {
                        Replace("ER");
                    }

                    break;

                case "Y":

                    if (char.IsDigit(character))
                    {
                        Replace("Z");
                    }

                    else
                    {
                        Replace("ER");
                    }
                    break;

                case "Z":

                    if (char.IsDigit(character))
                    {
                        Debug.Log("Avance en Z");
                    }

                    else if (character.Equals('+'))
                    {
                        Replace("+");
                    }

                    else if (character.Equals('-'))
                    {
                        Replace("-");
                    }

                    else if (character.Equals('*') || character.Equals('/') || character.Equals('%'))
                    {
                        Replace("S");
                    }

                    else if (character.Equals('<') || character.Equals('>') || character.Equals('!'))
                    {
                        Replace("B");
                    }

                    else if (character.Equals('='))
                    {
                        Replace("=");
                    }

                    else if (character.Equals('|'))
                    {
                        Replace("|");
                    }

                    else if (character.Equals('&'))
                    {
                        Replace("&");
                    }

                    else if (character.Equals(' '))
                    {
                        Replace("K");
                    }

                    else if (character.Equals(';'))
                    {
                        Replace("VAE");
                    }

                    else
                    {
                        Replace("ER");
                    }

                    break;
                case "VAE":
                    Debug.Log("Vuelve al autómata principal desde el de Pila");
                    AutomataController.instance.index = i - 1;
                    return AutomataType.MainStructure;

                case "ER":
                    return AutomataType.Error;
            }
        }

        //Con i procesamos el símbolo siguiente al que nos hace cambiar de estado
        //Con i-1 procesamos el símbolo que nos hace cambiar de estado en el otro Autómata

        if(stack.Pop().Equals("VAE"))
        {
            AutomataController.instance.index = line.Length - 1;
            return AutomataType.MainStructure;
        }
        return AutomataType.Error;
    }

    public void Replace(string symbol)
    {
        stack.Pop();
        stack.Push(symbol);
    }
}
