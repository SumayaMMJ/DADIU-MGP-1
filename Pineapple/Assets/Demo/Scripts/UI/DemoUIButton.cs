using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemoUIButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI printUIText;

    private Button button;
    private string printText;

    private void Awake()
    {
        transform.root.GetComponent<DemoUI>().button = this;
        button = GetComponent<Button>();

        if (!printUIText)
        {
            Debug.LogWarning("printUIText is null, please set up its reference, using the nearest child component instead", printUIText);
            printUIText = GetComponentInChildren<TextMeshProUGUI>();
        }
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
        printUIText.text = printText;
    }
}
