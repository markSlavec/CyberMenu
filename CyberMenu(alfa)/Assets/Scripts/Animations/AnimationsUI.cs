using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationsUI : MonoBehaviour
{
    public GameObject bookMenu;
    public GameObject backToMenu;
    public GameObject categoryName;
    public GameObject backToContent;
    public GameObject compoundButton;

    private RawImage _bookMenu;
    public RawImage _backToMenu;
    public RawImage _categoryName;
    public RawImage _backToContent;
    public RawImage _compoundButton;

    public float speed = 0.5f;

    private float targetOpacity = 1f;
    private float currentOpacity = 0f;


    private void Start()
    {
        _bookMenu = bookMenu.GetComponent<RawImage>();
        _backToMenu = backToMenu.GetComponent<RawImage>();
        _categoryName = categoryName.GetComponent<RawImage>();
        _backToContent = backToContent.GetComponent<RawImage>();
        _compoundButton = compoundButton.GetComponent<RawImage>();
    }


    private void Update()
    {
        // Increase opacity of first two images
        currentOpacity = Mathf.Lerp(currentOpacity, targetOpacity, speed * Time.deltaTime);
        _backToMenu.color = new Color(_backToMenu.color.r, _backToMenu.color.g, _backToMenu.color.b, currentOpacity);
        _categoryName.color = new Color(_categoryName.color.r, _categoryName.color.g, _categoryName.color.b, currentOpacity);

        // Decrease opacity of third image
        currentOpacity = Mathf.Lerp(currentOpacity, 0f, speed * Time.deltaTime);
        _bookMenu.color = new Color(_bookMenu.color.r, _bookMenu.color.g, _bookMenu.color.b, currentOpacity);
    }


}
