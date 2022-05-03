using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        _requestPanel.OnSearchNFTPictures += MadeRequest;
    }

    IEnumerator RequestNFT()
    {
        Toggle currentToggle = _requestPanel.ReturnActiveToggle();
        yield return new WaitForSeconds(1);
        Debug.Log(currentToggle.gameObject.name);
    }

    private void MadeRequest()
    {
        StartCoroutine(RequestNFT());
    }
}
