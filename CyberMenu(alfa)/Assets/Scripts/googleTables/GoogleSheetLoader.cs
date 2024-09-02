using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CVSLoader), typeof(SheetProcessor))]
public class GoogleSheetLoader : MonoBehaviour
{
    //public event Action<CubesData> OnProcessData;

    private string _sheetId;
    //[SerializeField] private CubesData _data;

    private CVSLoader _cvsLoader;
    private SheetProcessor _sheetProcessor;



    private void Start()
    {
        _cvsLoader = GetComponent<CVSLoader>();
        _sheetProcessor = GetComponent<SheetProcessor>();
        //DownloadTable();
    }

    public void DownloadTable(string category)
    {
        _sheetId = category;
        _cvsLoader.DownloadTable(_sheetId, OnRawCVSLoaded);
    }


    private void OnRawCVSLoaded(string rawCVSText)
    {
        _sheetProcessor.processData(rawCVSText);
    }
}