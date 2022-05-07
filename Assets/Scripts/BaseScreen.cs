using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    protected virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    protected virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void SwitchScreenTo(BaseScreen switchScreen)
    {
        Deactivate();
        switchScreen.Activate();
    }
}
