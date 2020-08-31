using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pineapple;

public class DemoUI : MonoBehaviour
{
    public DemoUITitle title;
    public DemoUIButton button;

    private void Awake()
    {
        DemoPlayerManager.Instance.DemoUI = this;
    }
}
