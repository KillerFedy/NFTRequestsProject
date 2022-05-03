using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NFTRequester : MonoBehaviour
{
    [SerializeField] private RequestPanelUIView _requestPanel;

    private Dictionary<string, string> requests = new Dictionary<string, string>()
    {
        {"owner", "https://ethereum-api.rarible.org/v0.1/nft/items/byOwner?owner=" },
        {"creator", "https://ethereum-api.rarible.org/v0.1/nft/items/byCreator?creator=" },
        {"collection", "https://ethereum-api.rarible.org/v0.1/nft/items/byCollection?collection=" }
    };

    private UnityWebRequest _request;

    private void Awake()
    {
        _requestPanel.OnSearchNFTPictures += MadeRequest;
    }

    IEnumerator RequestNFT()
    {
        ToggleInformation currentToggleInformation = _requestPanel.ReturnActiveToggle();
        _request = UnityWebRequest.Get(requests[currentToggleInformation.RequestInformationKey] + _requestPanel.TokenText);
        yield return _request.SendWebRequest();
        Debug.Log(_request.ToString());
    }

    private void MadeRequest()
    {
        StartCoroutine(RequestNFT());
    }
}
