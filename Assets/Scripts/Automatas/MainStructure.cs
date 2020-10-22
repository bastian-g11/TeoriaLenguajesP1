using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainStructure : Automata
{

    public void StructureReader(string lineToRead, int _index)
    {
        string line = lineToRead;
        string state = "IN";
        int index = _index;

        for (int i = index; i < line.Length; i++)
        {
            char character = line[i];

            if (state.Equals("E"))
            {
                Debug.Log("ERROR");
                break;
            }

            else if (Char.IsLetter(character))
            {
                ReservedWord rw = new ReservedWord();
                rw.StartAutomata(i);
                rw.FindReservedWord(line, rw.index);
                break;
            }

            else if (Char.IsDigit(character))
            {
                Debug.Log("ENTRÓ ");
                state = "E";
            }
        }
    }
}
