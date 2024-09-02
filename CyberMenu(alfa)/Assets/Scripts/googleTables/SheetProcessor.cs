using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SheetProcessor : MonoBehaviour
{
    loadObject _loadObject;
    private void Start()
    {
        _loadObject = GameObject.Find("Content").GetComponent<loadObject>();
    }

    private const int _id = 0;
    private const int _name = 1;
    private const int _URL = 2;
    private const int _nameDish = 3;
    private const int _compound = 4;
   
    private List<int> _listID = new List<int>();
    private List<string> _listName = new List<string>();
    private List<string> _listCompund = new List<string>();
    private List<string> _listNameDish = new List<string>();
    private List<string> _listURL = new List<string>();

    //

    private const char _cellSeporator = ',';
    private const char _inCellSeporator = ';';

    public void processData(string cvsRawData)
    {
        clearLists();
        char lineEnding = GetPlatformSpecificLineEnd();
        string[] rows = cvsRawData.Split(lineEnding);
        int dataStartRawIndex = 1;


        for (int i = dataStartRawIndex; i < rows.Length; i++)
        {
            string[] cells = rows[i].Split(_cellSeporator);
            _listID.Add(int.Parse(cells[_id]));
            _listName.Add(cells[_name]);
            _listURL.Add(cells[_URL]);
            _listNameDish.Add(cells[_nameDish]);
            _listCompund.Add(cells[_compound]);          
        }
        for (int i = 0; i < _listName.Count; i++)
        {
            print(_listName[i]);
        }

        startLoadObject();
    }

    private void clearLists()
    {
        _listID = new List<int>();
        _listName = new List<string>();
        _listCompund = new List<string>();
        _listNameDish = new List<string>();
        _listURL = new List<string>();
    }
    private void startLoadObject()
    {
        _loadObject.loadAsset(_listURL, _listName, _listNameDish, _listCompund);
    }

    private char GetPlatformSpecificLineEnd()
    {
        char lineEnding = '\n';
#if UNITY_IOS
        lineEnding = '\r';
#endif
        return lineEnding;
    }
}