using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManegerCategory : MonoBehaviour
{
    private GoogleSheetLoader _googleSheetLoader;
    private string _sheet_id;

    private List<int> _listID = new List<int>();
    private List<string> _listName = new List<string>();
    private List<string> _listCompund = new List<string>();
    private List<string> _listNameDish = new List<string>();
    private List<string> _listURL = new List<string>();

    private void Start()
    {
        _googleSheetLoader =GetComponent<GoogleSheetLoader>();
    }

    public void selectionCategory(string category)
    {
        switch (category)
        {
            case "Soup":
                _sheet_id = "ftp://u1810910:BQZ7gsl05iw9zbKW@31.31.198.99/tables/TableObjectsFirst.csv";
                getLists(_sheet_id);
                break;


            case "Salad":
                _sheet_id = "ftp://u1810910:BQZ7gsl05iw9zbKW@31.31.198.99/tables/TableObjectsSecond.csv";
                getLists(_sheet_id);
                break;
        }


    }


    private void getLists(string category)
    {
        _googleSheetLoader.DownloadTable(category);
        /*_googleSheetLoader.sendLists(out List<int> _listID, out List<string> _listName, out List<string> _listURL, out List<string> _listNameDish,
                                                                                                   out List<string> _listCompund);*/
    }

}
