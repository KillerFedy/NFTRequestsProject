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
    [SerializeField] private Text _errorText;

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

    protected override void Deactivate()
    {
        base.Deactivate();
        DisableInputText();
    }

    public void SetActiveErrorText(bool isActive)
    {
        _errorText.gameObject.SetActive(isActive);
        DisableInputText();
    }

    private void DisableInputText()
    {
        _tokenInput.text = "";
    }
}
