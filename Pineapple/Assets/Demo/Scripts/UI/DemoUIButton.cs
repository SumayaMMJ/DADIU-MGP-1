using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoUIButton : MonoBehaviour
{
    private Button button;
    private string printText;

    private void Awake()
    {
        transform.root.GetComponent<DemoUI>().button = this;
        button = GetComponent<Button>();
    }

    public void SetPrintText(string text) 
    {
        printText = text;
    }

    private void Start()
    {
        if (!button)
        {
            Debug.LogError("Button was null", button);
        }
        button.onClick.AddListener(PrintText);
    }

    private void PrintText() 
    {
        Debug.Log($"Printing text: {printText}");
    }
}
