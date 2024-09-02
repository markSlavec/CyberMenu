using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class categoryButtons : MonoBehaviour
{
    loadObject loadObjLink;
    //namesAndBundlesURL nameAndBundlesURLLink = new namesAndBundlesURL();
    ManegerCategory _managerCateogry;
    scrollBar _scrollBar;
    public addToBasket addToBasketLink;

    private List<int> _listID = new List<int>();
    private List<string> _listName = new List<string>();
    private List<string> _listCompund = new List<string>();
    private List<string> _listNameDish = new List<string>();
    private List<string> _listURL = new List<string>();

    private List<string> bundlesUrl = new List<string>();
    private List<string> names = new List<string>();


    private void Start()
    {
        loadObjLink = GameObject.Find("Content").GetComponent<loadObject>();
        
        _managerCateogry = GameObject.Find("Category").GetComponent<ManegerCategory>();
        _scrollBar = GameObject.Find("Content").GetComponent<scrollBar>();
    }

    private void OnMouseUpAsButton()
    {
        /*
        addToBasketLink.basketOn = false;
        nameAndBundlesURLLink.toNameAndBundles(gameObject.name, out bundlesUrl, out names);  // оформить в метод для последующих категорий эти две строчки
        loadObjLink.loadAsset(bundlesUrl, names);
        */
        
        addToBasketLink.basketOn = false;
        /*_managerCateogry.selectionCategory(gameObject.name, out _listID, out _listName, 
                                            out _listURL, out _listNameDish, out _listCompund); */
        _scrollBar.basketCategory = false;
        _managerCateogry.selectionCategory(gameObject.name);
        

    }



}

/*


public class namesAndBundlesURL : MonoBehaviour
{
    List<string> NameObjects = new List<string>();
    List<string> bundlesURL = new List<string>();
    private string nameObjectToShowCopy;
    private string compoundOfObjectCopy;

    public void toNameAndBundles(string nameCategory, out List<string> bundlesUrl, out List<string> name) // присваивание значений из контейнера; *** Методы связаны
    {
        conteinerNamesAndURL(nameCategory);

        name = NameObjects;
        bundlesUrl = bundlesURL;

    }


    public void conteinerNamesAndURL(string category) // Определение категории; *** Методы связаны
    {


        switch (category)
        {
            case "Soup":
                NameObjects = NameObjectsSoup;
                bundlesURL = bundlesURLSoup;
                break;

            case "Salad":
                NameObjects = NameObjectsSalad;
                bundlesURL = bundlesURLSalad;
                break;
        }

    }

    /*
    
    public void nameAndCompound(string nameObject, out string nameObjectToShow, out string compoundOfObject)
    {
        switch (nameObject)
        {
            case "plant":
                nameObjectToShowCopy = "Растение";
                compoundOfObjectCopy = "Классное серое растение. Видимо немного приболело.";
                break;

            case "eyeball":
                nameObjectToShowCopy = "Глазик";
                compoundOfObjectCopy = "Когда-нибудь все объекты будут крутиться. Дожить бы до этого.";
                break;

            case "hand":
                nameObjectToShowCopy = "Кисть";
                compoundOfObjectCopy = "Круто было бы елс она стояла. Однако увы, алгоритм этого не позволит, а если точнее моя лень.";
                break;

            case "spider":
                nameObjectToShowCopy = "Ебучий паук";
                compoundOfObjectCopy = "Иногда он меня пугает. В бессоные ночи он начинает двигаться.";
                break;


        }
        nameObjectToShow = nameObjectToShowCopy;
        compoundOfObject = compoundOfObjectCopy;
    }



    private List<string> bundlesURLSoup = new List<string>()
        {
        "ftp://u1782769:a5rFuBlyBa15L88y@31.31.198.99/public_html/plant.unity3d",
        "ftp://u1782769:a5rFuBlyBa15L88y@31.31.198.99/public_html/eyeball.unity3d",
        "ftp://u1782769:a5rFuBlyBa15L88y@31.31.198.99/public_html/hand.unity3d",
        "ftp://u1782769:a5rFuBlyBa15L88y@31.31.198.99/public_html/spider.unity3d"
        };

    private List<string> NameObjectsSoup = new List<string>() { "plant", "eyeball", "hand", "Only_Spider_with_Animations_Export" };


    private List<string> bundlesURLSalad = new List<string>()
        {
        "ftp://u1782769:a5rFuBlyBa15L88y@31.31.198.99/public_html/hand.unity3d",
        "ftp://u1782769:a5rFuBlyBa15L88y@31.31.198.99/public_html/spider.unity3d",
        };

    private List<string> NameObjectsSalad = new List<string>() { "hand", "Only_Spider_with_Animations_Export" };

    
}

*/


