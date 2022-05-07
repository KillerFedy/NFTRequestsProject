using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NFTRequester : MonoBehaviour
{
    [SerializeField] private RequestPanelUIView _requestPanel;
    [SerializeField] private int _countOfNFTItemsToFind;
    
    private List<string> _imagesUrls = new List<string>();
    private List<Texture> _imagesTextures = new List<Texture>();

    private Dictionary<string, string> requests = new Dictionary<string, string>()
    {
        {"owner", "https://ethereum-api.rarible.org/v0.1/nft/items/byOwner?owner=" },
        {"creator", "https://ethereum-api.rarible.org/v0.1/nft/items/byCreator?creator=" },
        {"collection", "https://ethereum-api.rarible.org/v0.1/nft/items/byCollection?collection=" }
    };

    public UnityEvent<List<Texture>> OnSuccessRequest;
    public UnityEvent OnErrorRequest;

    private IEnumerator RequestNFTWebSite()
    {
        ToggleInformation currentToggleInformation = _requestPanel.ReturnActiveToggle();
        UnityWebRequest request = UnityWebRequest.Get(requests[currentToggleInformation.RequestInformationKey] + _requestPanel.TokenText);
        yield return request.SendWebRequest();
        string resultOfRequest = request.downloadHandler.text;
        if((request.isNetworkError || request.isHttpError) || (IsItemsEmpty(resultOfRequest)))
        {
            OnErrorRequest?.Invoke();
        }
        else
        {
            FindLinkToImages(resultOfRequest);
            GetPicturesFromUrls();
            StartCoroutine(WaitForFullImageList());
        }
    }

    private IEnumerator WaitForFullImageList()
    {
        yield return new WaitUntil(IsImagesListFull);
        OnSuccessRequest?.Invoke(_imagesTextures);
    }

    private void MadeRequest()
    {
        StartCoroutine(RequestNFTWebSite());
    }

    private bool IsItemsEmpty(string result)
    {
        int indexOfCountItems = 9;
        return result[indexOfCountItems] == '0';
    }

    private void FindLinkToImages(string result)
    {
        _imagesUrls.Clear();
        string textToFind = "\"image\":{\"url\":{\"ORIGINAL\"";
        int i = 0;
        int y = result.IndexOf(textToFind, 0);
        while ((i < _countOfNFTItemsToFind) && (y != -1))
        {
            string url = "https";
            int start = result.IndexOf(url, y);
            int finish = result.IndexOf("\"", start);
            url = result.Substring(start, finish - start);
            _imagesUrls.Add(url);
            y = result.IndexOf(textToFind, y + textToFind.Length);
            i++;
        }
    }

    private IEnumerator GetPictureFromURL(string urlImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(urlImage);
        yield return request.SendWebRequest();
        _imagesTextures.Add(DownloadHandlerTexture.GetContent(request));
    }

    private void GetPicturesFromUrls()
    {
        _imagesTextures.Clear();
        foreach (string url in _imagesUrls)
        {
            StartCoroutine(GetPictureFromURL(url));
        }
    }

    private bool IsImagesListFull()
    {
        return (_countOfNFTItemsToFind == _imagesTextures.Count);
    }    
}
