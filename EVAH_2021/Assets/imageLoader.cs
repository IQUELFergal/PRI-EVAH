using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageLoader : MonoBehaviour
{
    string url = "https://www.mairie-francheville69.fr/wp-content/uploads/2017/11/image-test-1024x640.jpeg";
    public Renderer thisRenderer;

    // automatically called when game started
    void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine()); // execute the section independently

        // the following will be called even before the load finished
        thisRenderer.material.color = Color.red;
    }

    // this section will be run independently
    private IEnumerator LoadFromLikeCoroutine()
    {
        Debug.Log("Loading ....");
        WWW wwwLoader = new WWW(url);   // create WWW object pointing to the url
        yield return wwwLoader;         // start loading whatever in that url ( delay happens here )

        Debug.Log("Loaded");
        thisRenderer.material.color = Color.white;              // set white
        thisRenderer.material.mainTexture = wwwLoader.texture;  // set loaded image
    }

}
