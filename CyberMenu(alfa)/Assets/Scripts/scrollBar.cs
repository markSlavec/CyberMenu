using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;




public class scrollBar : MonoBehaviour
{

    //[Range(0, 30)]
    [Header("Controllers")]
    private int panCount = 0;
    [Range(0, 700)]
    public float spacing;
    [Range(1f, 20f)]
    public float snapSpeed;
    [Range(0f, 10f)]
    public float scaleOffset;
    [Range(0f, 20f)]
    public float scaleSpeed;

    [Header("Other objects")]

    public GameObject panPrefab;
    public GameObject[] instsPans;
    public Vector3[] pansPos;
    public ScrollRect scrollRect;
    public int selectedPanID;
    public RectTransform contentRect;
    public Transform content;
    public bool basketCategory = false;
    private float rotateSpeed = 14f;

    private bool isScrolling;
    private Vector3 contentVector;
    private Vector3[] pansScale;
    private int countPenPrefab;
    private bool onOffUpdate = false;
    private bool onOffLoad = false;
    private int countObject;

    GameObject[] instsPansCopy;
    Vector3[] pansPosCopy;
    Vector3[] pansScaleCopy;
    private int a;
    public loadObject loadObjectLink;
    public showNamesAndAmounts showNamesAndAmountsLink;

    private void Start() // мб стоит поправить и сделать обычную ссылку; ќформить при оптимизации;
    {
        loadObjectLink = GameObject.Find("Content").GetComponent<loadObject>();

    }

    public void cleanContent()
    {
        if (content == null)
            return;

        onOffUpdate = false;
        for (int i =0; i < instsPans.Length; i++)
        {
            Destroy(instsPans[i]);
        }

        pansPos = new Vector3[2];
        instsPans = new GameObject[2];
        pansScale = new Vector3[2];

        panCount = 0;

    }

    public void contentToStart()
    {
        contentRect.anchoredPosition = new Vector3(0,0,0);
    }


    public void addObject(GameObject objectToArray)
    {
        if (panCount > 0)
            Destroy(instsPans[panCount]);

        instsPansCopy = instsPans; 
        pansPosCopy = pansPos;
        pansScaleCopy = pansScale;

        if (panCount < countObject - 1)
            a = 2;
        else a = 1;

        pansPos = new Vector3[panCount + a];
        instsPans = new GameObject[panCount + a];
        pansScale = new Vector3[panCount + a];

        for (int i = 0; i < panCount + 1; i++)
        {
            if (i == panCount)
            {

                positionAndAddArray(panCount, objectToArray);
                if (basketCategory == false)
                    instsPans[panCount].AddComponent<amountObject>().giveNameAndCompound(loadObjectLink.getName(), loadObjectLink.getCompound()); // проверка можно ли дать скрипт вместе в значени€ми
                instsPans[panCount].name = objectToArray.name;
                //instsPans[panCount].GetComponent<amountObject>().giveNameAndCompound(name, compound); // проверка
            }
            else
            {
                pansPos[i] = pansPosCopy[i];
                instsPans[i] = instsPansCopy[i];
                pansScale[i] = pansScaleCopy[i];
            }

        }

        if (panCount < countObject - 1)
            positionAndAddArray(panCount + 1, panPrefab);


        onOffLoad = false;
        onOffUpdate = true;
        panCount++;

    }


    private void positionAndAddArray(int i, GameObject objectToScroll)
    {
        instsPans[i] = Instantiate(objectToScroll, transform, false);
        instsPans[i].transform.localPosition = new Vector3(spacing * i, panPrefab.transform.localPosition.y, panPrefab.transform.localPosition.z);
        pansPos[i] = -instsPans[i].transform.localPosition;
    }


    public void counterObjects(int countObject) // количество объектов в категории
    {
        this.countObject = countObject;
    }


    public void FixedUpdate()
    {
        if (onOffUpdate == false)
        {
            return;
        }

        

        if (contentRect.anchoredPosition.x <= pansPos[0].x || contentRect.anchoredPosition.x >= pansPos[pansPos.Length - 1].x)
        {
            isScrolling = false;
            scrollRect.inertia = false;
        }



        float nerestPos = float.MaxValue;
        for (int i = 0; i < instsPans.Length; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distance < nerestPos)
            {
                

                nerestPos = distance;
                selectedPanID = i;

            }
            float scale = Mathf.Clamp(65 / (distance / spacing) * scaleOffset, 25, 65);
            pansScale[i].x = Mathf.SmoothStep(instsPans[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(instsPans[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].z = Mathf.SmoothStep(instsPans[i].transform.localScale.z, scale, scaleSpeed * Time.fixedDeltaTime);

            instsPans[i].transform.localScale = pansScale[i];


            if (showNamesAndAmountsLink.nameObjectCopy == instsPans[i].name)
            {
                instsPans[i].gameObject.transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.fixedDeltaTime);
            }

        }
        if (isScrolling) return;
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;




        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling)
            scrollRect.inertia = false;

        


    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;

    }
}


