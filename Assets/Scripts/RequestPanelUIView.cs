using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RequestPanelUIView : BaseScreen
{
    [SerializeField] private List<ToggleInformation> _togglesInformations;
    [SerializeField] private Button _searchButton;
    [SerializeField] private Text _token;

    public string TokenText => _token.text;

    public UnityAction OnSearchNFTPictures;
    
    private void Start()
    {
        _searchButton.onClick.AddListener(OnSearchNFTPictures);    
    }
    
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
    }

    protected override void Deactivate()
    {
        base.Deactivate();
    }
}
