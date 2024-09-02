using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nameAnOrder : MonoBehaviour
{
    public float spasing = 0.5f; 

    public  basketArray basketArray;
    public TextMeshProUGUI nameObjectText;     
    public TextMeshProUGUI amountText;
    public RectTransform content;
    public generatQRCode _generatQRCode;
    //private namesAndBundlesURL namesAndBundlesURL = new namesAndBundlesURL();


    private void Start()
    {
        _generatQRCode = GetComponent<generatQRCode>();
    }

    private void OnMouseUpAsButton()
    {
        for (int i = 0; i < basketArray.ObjectsToBasket.Count; i++)
        {
            amountText.text += basketArray.ObjectsToBasket[i].GetComponent<amountObject>().totalAmount.ToString() + "\n\n";
            nameObjectText.text += basketArray.ObjectsToBasket[i].GetComponent<amountObject>().getName() + "\n\n";

            //content.localScale = new Vector3(content.localScale.x + i * spasing, content.localScale.y, content.localScale.z);

        }
        _generatQRCode.encoderButyon();

    }

    public void cleanChekList()
    {
        nameObjectText.text = "";
        amountText.text = "";
    }
   
    
}
