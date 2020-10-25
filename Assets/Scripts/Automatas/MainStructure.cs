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

        for (int i = index; i < line.Length; i++)
        {
            char character = line[i];
            if (Char.IsLetter(character))
            {
                AutomataController.instance.index = i;
                Debug.Log("Entró a palabras reservadas");
                return AutomataType.ReservedWord;
            }
            else if (character.Equals(' '))
            {
                Debug.Log("Espacio");
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
