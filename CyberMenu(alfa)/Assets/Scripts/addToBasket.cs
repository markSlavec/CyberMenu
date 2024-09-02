using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addToBasket : MonoBehaviour
{
    public Transform basket;
    public scrollBar scrollBarLink;
    public List<GameObject> basketArrayLinkObjectsToBasket = new List<GameObject>();
    public basketArray basketArrayLink;
    public showNamesAndAmounts showNamesAndAmountsLink;
    public basketButton basketButtonLink;
    private int amountObjectBasket = 0;
    private bool basketHaveObject = false;
    public bool basketOn = false;


    public void amountAndName(string objectToshow)
    {
        Debug.Log(objectToshow);

    }


    private void OnMouseUpAsButton()
    {

        switch (gameObject.name)
        {
            case "Add":
                AddObjectToBasket();
                break;

            case "Put away":
                putAwayInBusket();
                break;


        }

    }


    private void putAwayInBusket()
    {
        for (int i = 0; i < basketArrayLink.amountObjectBasket; i++)
        {
            if (scrollBarLink.instsPans[scrollBarLink.selectedPanID].name == basketArrayLink.ObjectsToBasket[i].name)
            {
                basketArrayLink.ObjectsToBasket[i].GetComponent<amountObject>().totalAmount--;
                
                if (basketArrayLink.ObjectsToBasket[i].GetComponent<amountObject>().totalAmount == 0)
                {
                    Destroy((basketArrayLink.ObjectsToBasket[i]));
                    basketArrayLink.ObjectsToBasket.RemoveAt(i);
                    basketArrayLink.amountObjectBasket--;

                    if (basketOn == true)
                        basketButtonLink.addBusketToScrollBar();

                }
                showNamesAndAmountsLink.showAndChangeAmount(); // Обновляет счет на сцене
                return;
            }
        }

    }

    private void AddObjectToBasket()  // сделать switch под разные разпросы: добавить убрать, показать число добавлений в сцене;
    {
        if (basketArrayLink.amountObjectBasket == 0)
        {
            basketArrayLink.amountObjectBasket++;
            basketArrayLink.toBasket(scrollBarLink.instsPans[scrollBarLink.selectedPanID]);
            showNamesAndAmountsLink.showAndChangeAmount(); // Обновляет счет на сцене
            return;
        }



        for (int i = 0; i < basketArrayLink.amountObjectBasket; i++)
        {
            if (scrollBarLink.instsPans[scrollBarLink.selectedPanID].name == basketArrayLink.ObjectsToBasket[i].name)
            {
                basketArrayLink.ObjectsToBasket[i].GetComponent<amountObject>().totalAmount++;
                basketHaveObject = true;
            }
        }   
            
        if (basketHaveObject == false)
        {
            basketArrayLink.amountObjectBasket++;
            basketArrayLink.toBasket(scrollBarLink.instsPans[scrollBarLink.selectedPanID]);
        }
        basketHaveObject = false;

        showNamesAndAmountsLink.showAndChangeAmount(); // Обновляет счет на сцене
    }


}
