using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketArray : MonoBehaviour
{

    public scrollBar scrollBarLink;
    [SerializeField] GameObject objectToBusketPrefab;


    public List<GameObject> ObjectsToBasket = new List<GameObject>();
    public int amountObjectBasket = 0;


    public void toBasket(GameObject addObjectToBasket)
    {
        ObjectsToBasket.Add(Instantiate(scrollBarLink.instsPans[scrollBarLink.selectedPanID], transform));
        ObjectsToBasket[amountObjectBasket - 1].name = scrollBarLink.instsPans[scrollBarLink.selectedPanID].name;
        ObjectsToBasket[amountObjectBasket - 1].GetComponent<amountObject>().totalAmount++;
    }




    string amountObject;  // пустой объект;

    public string getObjectAmount(string nameObject)
    {
        if (amountObjectBasket != 0)
        {
            for (int i = 0; i < amountObjectBasket; i++)
            {
                if (ObjectsToBasket[i].name == nameObject)
                {
                    return ObjectsToBasket[i].GetComponent<amountObject>().totalAmount.ToString();                    
                }
            }
        }
        else
            amountObject = "";
        return amountObject;
    }

    

}
