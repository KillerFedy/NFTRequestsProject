using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInformation : MonoBehaviour
{
    [SerializeField] private string _requestInformationKey;

    private Toggle _toggle;

    public Toggle Toggle => _toggle;
    
    public string RequestInformationKey => _requestInformationKey;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
    }
}
