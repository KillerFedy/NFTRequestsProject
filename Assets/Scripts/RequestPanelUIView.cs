using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RequestPanelUIView : MonoBehaviour
{
    [SerializeField] private List<Toggle> _toggles;
    [SerializeField] private Button _searchButton;
    [SerializeField] private Text _token;

    public Text Token
    {
        get { return _token; }
    }

    public UnityAction OnSearchNFTPictures;
    
    private void Start()
    {
        _searchButton.onClick.AddListener(OnSearchNFTPictures);    
    }
    
    public Toggle ReturnActiveToggle()
    {
        for(int i = 0; i < _toggles.Count; i++)
        {
            if(_toggles[i].isOn)
            {
                return _toggles[i];
            }
        }
        return null;
    }
}
