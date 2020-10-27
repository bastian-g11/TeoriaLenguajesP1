using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainStructure 
{

    public AutomataType ReadStructure(string lineToRead, int _index)
    {
        string line = lineToRead;
        int index = _index;
        char character;

        for (int i = index; i < line.Length; i++)
        {
            character = line[i];
            if (Char.IsLetter(character))
            {
                AutomataController.instance.index = i;
                Debug.Log("Entró a palabras reservadas");
                Debug.Log("Entró con: "+character);
                return AutomataType.ReservedWord;
            }
            else if (character.Equals(' '))
            {
                Debug.Log("Espacio");
            }

            else if (character.Equals(';'))
            {
                Debug.Log("Entró un ;");
            }
            else if (Char.IsDigit(character))
            {
                Debug.Log("Entró a error en MainStructure");
                return AutomataType.Error;
            }
            else
            {
                return AutomataType.Error;
            }
        }
        return AutomataType.None;
    }
}
