using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoUITitle : MonoBehaviour
{
    private TextMeshProUGUI titleText;

    private void Awake()
    {
        transform.root.GetComponent<DemoUI>().title = this;
        titleText = GetComponent<TextMeshProUGUI>();
    }

    public void SetTitleText(string text) 
    {
        if (null == titleText)
        {
            Debug.LogError("Title Text was null!", titleText);
        }

        titleText.text = text;
    }
}
