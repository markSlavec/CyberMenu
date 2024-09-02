using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketButton : MonoBehaviour
{
    public scrollBar scrollBarLink;
    public basketArray basketArrayLink;
    public loadObject loadObjectLink;
    public addToBasket addToBasketLink;
    CameraController cameraController;

    private void Start()
    {
        cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
    }


    private void OnMouseUpAsButton()
    {
        addBusketToScrollBar();
        scrollBarLink.contentToStart();
        cameraController.MoveCamera();
    }

    public void addBusketToScrollBar()
    {
        
        scrollBarLink.cleanContent();
        
        scrollBarLink.basketCategory = true;
        scrollBarLink.counterObjects(basketArrayLink.ObjectsToBasket.Count);
        loadObjectLink.basketOn = true;
        addToBasketLink.basketOn = true;

        for (int i = 0; i < basketArrayLink.ObjectsToBasket.Count; i++)
        {
            scrollBarLink.addObject(basketArrayLink.ObjectsToBasket[i]);

        }
        
    }

    public void addObjectToScrollBar()
    {
        scrollBarLink.basketCategory = true;
        scrollBarLink.counterObjects(basketArrayLink.ObjectsToBasket.Count);
        loadObjectLink.basketOn = true;
        addToBasketLink.basketOn = true;

        for (int i = 0; i < basketArrayLink.ObjectsToBasket.Count; i++)
        {
            scrollBarLink.addObject(basketArrayLink.ObjectsToBasket[i]);

        }
    }
}
