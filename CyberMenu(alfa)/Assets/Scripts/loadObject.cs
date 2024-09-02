using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadObject : MonoBehaviour
{

    int version = 0;
    GameObject chekBoxSource;

    public bool basketOn = false;

    public Transform prefabContent;
    private scrollBar scrollBarLink;
    private string nameObject; 
    private List<string> NameObjects; 
    private List<string> bundlesURL; 
    private List<string> nameDish;
    private List<string> listCompound;
    private int countObjects;

    private int counterObject = 0; // костыль для 


    private void Start()
    {
        scrollBarLink = GameObject.Find("Content").GetComponent<scrollBar>();

    }




    public void loadAsset( List<string> bundlesURL, List<string> NameObjects, List<string> nameDish, List<string> listCompound)
    {
        if(this.bundlesURL == bundlesURL && this.NameObjects == NameObjects && basketOn == false)
            return;

        counterObject = 0;  

        scrollBarLink.cleanContent();
        this.nameDish = nameDish;
        this.listCompound = listCompound;
        this.bundlesURL = bundlesURL;
        this.NameObjects = NameObjects;
        StartCoroutine(DowloadAndCachBox());

        countObjects = bundlesURL.Count;
        scrollBarLink.counterObjects(countObjects);

        basketOn = false;
    }


    public void loadAssetExtra ()
    {
        if(counterObject < countObjects)
            StartCoroutine(DowloadAndCachBox());
    }



    IEnumerator DowloadAndCachBox()
    {
        while (!Caching.ready)
            yield return null;
        var www = WWW.LoadFromCacheOrDownload(bundlesURL[counterObject], 5);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        Debug.Log("Бандл загружен");
        var assetBunle = www.assetBundle;
        string nameObjectToLoad = NameObjects[counterObject] + ".obj"; // формат файла (лушче создавать модели fbx)
        var boxRequest = assetBunle.LoadAssetAsync(nameObjectToLoad, typeof(GameObject));
        yield return boxRequest;
        Debug.Log("Бокс распакован");

        chekBoxSource = boxRequest.asset as GameObject;

        if (counterObject == 0)
            scrollBarLink.contentToStart();

        scrollBarLink.addObject(chekBoxSource);
        assetBunle.Unload(false);
        www.Dispose();

        counterObject++; // счетчик блюд

        yield break;
    }

    public string getName()
    {
        return nameDish[counterObject];
    }

    public string getCompound()
    {
        return listCompound[counterObject];
    }
}