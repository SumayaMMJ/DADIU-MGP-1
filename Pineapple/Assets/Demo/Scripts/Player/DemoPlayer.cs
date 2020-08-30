using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pineapple;

public class DemoPlayer : MonoBehaviour
{

    private void Awake()
    {
        DemoPlayerManager.Instance.DemoPlayer = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DemoPlayerManager.Instance.DemoUI.title.SetTitleText($"Player Name: {gameObject.name}");
            DemoPlayerManager.Instance.DemoUI.button.SetPrintText(gameObject.name);
        }
    }
}
