using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text txt;
    public Text errorText;
    public string lineaTexto;
    public GameObject go_uiNode;
    public Node createdNode;
    public Transform nodeContainer;
    public int distance = 2;


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
            errorText.text = errorText.text + "Errores en la línea: " + lineNumber + " \n" +
                        ErrorController.instance.GetLineErrors(); ;
            ErrorController.instance.RestartErrors();
        }
    }

    public void CreateUINode()
    {
        GameObject _go = Instantiate(go_uiNode, Vector3.right * distance, Quaternion.identity,nodeContainer);
        distance = distance + 5;
        UINode _uiNode = _go.GetComponent<UINode>();
        createdNode.SetUINode(_uiNode);
        _uiNode.SetUINode(createdNode);
    }
}
