using UnityEngine;
using UnityEngine.UI;

public class RorationObject : MonoBehaviour
{
    public float scale = 65f;
    private scrollBar _scrollBar;
    private GameObject _content;
    private GameObject _containerForObject;
    private showNamesAndAmounts _showNamesAndAmounts;
    private GameObject _objectToRotation;
    private ScrollRect _scrollRect;
    private float _lastClickTime;
    private float _timeSinceLastClick;
    private const float _doubleClickTIme = .5f;
    private bool onOffUpdate = false;
    private bool onOffDoubleClick = true;
    private float rotateSpeed = 14f;
    private GameObject _category;
    private GameObject _backToContent;
    private Transform _compundObject;
    public bool isScrolling;
    private GameObject _compoundButton;
    private CameraController cameraControler;

    public Animator anim;
    public string animName;


    public float rotatespeed = 10f;
    private float _startingPosition;


    private void Start() // стоит попправить find. Вместо этого сделть аналогично offIconMenuAndOnBackToContent в этом же классе; 
    {
        _containerForObject = GameObject.Find("ContainerForObjectToRotation");
        _showNamesAndAmounts = GameObject.Find("GetNameObject").GetComponent<showNamesAndAmounts>();
        _scrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        _content = GameObject.Find("Content");
        _scrollBar = _content.GetComponent<scrollBar>();
        _category = GameObject.Find("Category");
        _compoundButton = _category.transform.Find("CompoundButton").gameObject;
        //_compoundButton = GameObject.Find("CompoundButton");
        _compundObject = _compoundButton.transform.GetChild(0);
        _compundObject.gameObject.SetActive(false);
        _compoundButton.SetActive(false);    }

    private void OnMouseUpAsButton()
    {
        if (_showNamesAndAmounts.sendNameObjectAtTheMoment() != _scrollBar.panPrefab.name && onOffDoubleClick ==true ) // можно создать отельную переменную для имени префаба
        {
            _timeSinceLastClick = Time.time - _lastClickTime;
            if (_timeSinceLastClick <= _doubleClickTIme && _showNamesAndAmounts.sendObjectAtTheMoment().name != "Sample(Clone)")        // doubleClick
            {              
                creatPositionOnSpace();
                onOffDoubleClick = false;
                onOffUpdate = true;

                offIconMenuAndOnBackToContent();

                anim.Play(animName);

            }
            _lastClickTime = Time.time;
        }
    }

    private void offIconMenuAndOnBackToContent()
    {
        _category.transform.Find("bookMenu").gameObject.SetActive(false);
        _category.transform.Find("backToMenu").gameObject.SetActive(false);
        _category.transform.Find("categoryName").gameObject.SetActive(false);
        _category.transform.Find("backToContent").gameObject.SetActive(true);
        _compoundButton.SetActive(true);
        //_compundObject.SetActive(true);


    }

    private void creatPositionOnSpace()
    {
        _containerForObject.SetActive(true);
        _scrollRect.enabled = false;
        _content.SetActive(false);

        _objectToRotation = Instantiate(_showNamesAndAmounts.sendObjectAtTheMoment(), _containerForObject.transform);
        _objectToRotation.name = _showNamesAndAmounts.sendNameObjectAtTheMoment();
        _objectToRotation.transform.localPosition = new Vector3(_scrollBar.panPrefab.transform.localPosition.x, _scrollBar.panPrefab.transform.localPosition.y, _scrollBar.panPrefab.transform.localPosition.z);
        _objectToRotation.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void backToContainerManager()
    {
        onOffUpdate = false;
        Destroy(_objectToRotation);
        _compundObject.gameObject.SetActive(false);
        _compoundButton.SetActive(false);
        _containerForObject.SetActive(false);
        _category.transform.Find("backToContent").gameObject.SetActive(false);
        _category.transform.Find("bookMenu").gameObject.SetActive(true);
        _scrollRect.enabled = true;
        _content.SetActive(true);
        onOffDoubleClick = true;
        


    }

    private void FixedUpdate()
    {

        if (onOffUpdate == false)
            return;


        



        if (Input.touchCount > 0 && isScrolling == false)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (_startingPosition > touch.position.x)
                    {
                        _objectToRotation.transform.Rotate(Vector3.down, -rotatespeed);
                    }
                    else if (_startingPosition < touch.position.x)
                    { 
                        _objectToRotation.transform.Rotate(Vector3.down, rotatespeed);
                    }
                    break;  

                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        }

        else
        {
            _objectToRotation.gameObject.transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.fixedDeltaTime);
        }

    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;

    }

}



