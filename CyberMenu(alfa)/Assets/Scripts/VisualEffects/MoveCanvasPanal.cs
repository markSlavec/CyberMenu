using UnityEngine;
public class MoveCanvasPanal : MonoBehaviour
{
    private Canvas canvasObjct;
    public RectTransform canvasPosition;
    public RectTransform startPostion;
    public RectTransform busketPostion;
    private bool checkPosition;

    private bool changeRender;

    private void Start()
    {
        canvasObjct = canvasPosition.GetComponent<Canvas>();
    }

    public void OnOffRenderMode()
    {
        changeRender = !changeRender;
        if (changeRender) 
            canvasObjct.renderMode = RenderMode.WorldSpace;
        else
            canvasObjct.renderMode = RenderMode.ScreenSpaceCamera;
        
    }

    
    public void changePositionCanva()
    {
        checkPosition = !checkPosition;
        if (checkPosition)
            canvasPosition.position = busketPostion.position;
        else
            canvasPosition.position = startPostion.position;
    }
    
}
