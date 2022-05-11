using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RequestPanelUIView : BaseScreen
{
    [SerializeField] private List<ToggleInformation> _togglesInformations;
    [SerializeField] private Button _searchButton;
    [SerializeField] private InputField _tokenInput;
    [SerializeField] private Text _informationText;

    public string TokenText => _tokenInput.text;

    public ToggleInformation ReturnActiveToggle()
    {
        for(int i = 0; i < _togglesInformations.Count; i++)
        {
            if(_togglesInformations[i].Toggle.isOn)
            {
                return _togglesInformations[i];
            }
        }
        return null;
    }

    protected override void Activate()
    {
        base.Activate();
        SetInformationText("");
        DisableInputText();
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        DisableInputText();
    }

    public void SetInformationText(string info)
    {
        _informationText.text = info;
    }

    public void DisableInputText()
    {
        _tokenInput.text = "";
    }
}
