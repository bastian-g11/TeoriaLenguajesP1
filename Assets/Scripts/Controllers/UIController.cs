using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text txt;
    public Text errorText;
    public string lineaTexto;

    #region singleton
    public static UIController instance;
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

    public void SetText()
    {
        lineaTexto = txt.text;
        Debug.Log(lineaTexto);
        AutomataController.instance.index = 0;
        errorText.text = " ";
        TextReader.instance.Recorrer(lineaTexto);
    }

    public void SetErrorText(int lineNumber)
    {
        if (ErrorController.instance.GetLineHasError())
        {
            errorText.text = "Error en la línea: " + lineNumber + " \n" +
                        ErrorController.instance.GetLineErrors(); ;
            ErrorController.instance.RestartErrors();
        }
    }
}
