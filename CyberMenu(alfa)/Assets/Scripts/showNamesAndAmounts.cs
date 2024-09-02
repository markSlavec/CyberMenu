using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showNamesAndAmounts : MonoBehaviour
{
    public loadObject loadObjectLink;
    public scrollBar scrollBarLink;
    public basketArray basketArrayLink;

    public TextMeshProUGUI nameObjectText;
    public TextMeshProUGUI comoundObjectText;
    public TextMeshProUGUI amountObjectText;
    //private namesAndBundlesURL namesAndBundlesURLlink = new namesAndBundlesURL();
    private string nameObject;
    public string nameObjectCopy = "start"; // для showAndChangeAmount
    private string nameObjectToShow;
    private string compoundToShow;
    private bool onOffLoad = false;
    private GameObject _objectToSend;
    private amountObject _amountObject;
    private GameObject _compoundButton;


    private void Start()
    {
        _compoundButton = GameObject.Find("CompoundButton");
    }

    private void OnTriggerStay(Collider other)   // может стоит поменять на triggerEnter, так как префаб удаляется, а новый загружается. Стоит проверить для оптимизации;
    {
        _objectToSend = other.gameObject;
        nameObjectCopy = _objectToSend.name; 

        if (other.gameObject.name != nameObject && other.gameObject.name != "Sample(Clone)") // Подгружает названия объекта;
        {
            _amountObject = other.gameObject.GetComponent<amountObject>();
            nameObjectText.text = _amountObject.getName();
            comoundObjectText.text = _amountObject.getCompound();
            showAndChangeAmount();
            onOffLoad = false;
            /*
            namesAndBundlesURLlink.nameAndCompound(other.gameObject.name, out nameObjectToShow, out compoundToShow);
            nameObjectText.text = nameObjectToShow; // Имя объекта;
            comoundObjectText.text = compoundToShow; // Состав объекта;
            showAndChangeAmount();
            onOffLoad = false;
            */
        }
        else if (other.gameObject.name != nameObject && other.gameObject.name == "Sample(Clone)" && onOffLoad == false) // Подгружает объекты при скролле;
        {
            loadObjectLink.loadAssetExtra();
            onOffLoad = true;
        }

        nameObject = _objectToSend.name;
    }

    public void showAndChangeAmount()
    {        
        amountObjectText.text = basketArrayLink.getObjectAmount(nameObjectCopy);
    }

    public string sendNameObjectAtTheMoment()
    {
        return nameObjectCopy;
    }

    public GameObject sendObjectAtTheMoment()
    {
        return _objectToSend;
    }
}


