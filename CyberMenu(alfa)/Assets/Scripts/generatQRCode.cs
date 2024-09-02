using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using TMPro;

public class generatQRCode : MonoBehaviour
{
    public basketArray basketArrayLink;
    [SerializeField]
    private RawImage _rawImageReciver;  
    private string _textToQRCode;
    //private namesAndBundlesURL namesAndBundlesURL = new namesAndBundlesURL();
    private Texture2D _storeEncoderTexture;

    private void Start()
    {
        basketArrayLink = GameObject.Find("basket").GetComponent<basketArray>();
        _storeEncoderTexture = new Texture2D(256, 256);        
    }

    private Color32[] Encode(string textForEncodeing, int width, int height)
    {

        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };

        return writer.Write(textForEncodeing);


    }

    public void encoderButyon ()
    {
        

        EncoderTextToQRcode();
    }

    private void EncoderTextToQRcode()
    {


        for (int i = 0; basketArrayLink.ObjectsToBasket.Count > i; i++)
        {
            _textToQRCode += basketArrayLink.ObjectsToBasket[i].GetComponent<amountObject>().getName();
            
        };

        Color32[] _converPixelToTexture = Encode(_textToQRCode, _storeEncoderTexture.width, _storeEncoderTexture.height);

        _storeEncoderTexture.SetPixels32(_converPixelToTexture);
        _storeEncoderTexture.Apply();

        _rawImageReciver.texture = _storeEncoderTexture;
        Debug.Log(_textToQRCode);
    }

}
