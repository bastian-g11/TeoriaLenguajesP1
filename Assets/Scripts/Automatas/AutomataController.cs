using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomataController : MonoBehaviour
{
    public int index;
    public AutomataType nextAutomata;

    #region Automatas
    MainStructure mc;
    ReservedWord rw;
    VariableSyntax vs;
    StackAutomata sa;
    #endregion

    #region singleton
    public static AutomataController instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        mc = new MainStructure();
        rw = new ReservedWord();
        vs = new VariableSyntax();
        sa = new StackAutomata();
        nextAutomata = AutomataType.MainStructure;
        index = 0;
    }

    public AutomataType StartMainStructure(string lineToRead, int _index)
    {
        return mc.ReadStructure(lineToRead, _index);
    }

    public AutomataType StartReserverdWord(string lineToRead, int _index)
    {
        return rw.FindReservedWord(lineToRead, _index);
    }

    public AutomataType StartVariableSyntax(string lineToRead, int _index)
    {
        return vs.CheckVariableSyntax(lineToRead, _index);
    }

    public AutomataType StartStackAutomata(string lineToRead, int _index)
    {
        return sa.CheckRightSideStructure(lineToRead, _index);
    }
}
