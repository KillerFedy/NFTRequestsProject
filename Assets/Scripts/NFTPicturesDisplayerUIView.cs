using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NFTPicturesDisplayerUIView : BaseScreen
{
    [SerializeField] private List<RawImage> rawImages;

    private void SetTexturesToImages(List<Texture> textures)
    {
        for(int i = 0; i < textures.Count; i++)
        {
            rawImages[i].texture = textures[i];
        }
    }
}
