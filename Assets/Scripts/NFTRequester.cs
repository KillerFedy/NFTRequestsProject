using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTRequester : MonoBehaviour
{
    [SerializeField] private RequestPanelUIView _requestPanel;

    private Dictionary<string, string> requests = new Dictionary<string, string>()
    {
        {"owner", "https://ethereum-api.rarible.org/v0.1/nft/items/byOwner?owner=" },
        {"creator", "https://ethereum-api.rarible.org/v0.1/nft/items/byCreator?creator=" },
        {"collection", "https://ethereum-api.rarible.org/v0.1/nft/items/byCollection?collection=" }
    };
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
