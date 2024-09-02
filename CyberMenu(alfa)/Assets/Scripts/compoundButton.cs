
using UnityEngine;

public class compoundButton : MonoBehaviour
{
    private Transform _compoundButton;
    private Transform _childCompundText;
    private int counter = 0;
    public Animator anim;
    public string openCompoundAnime = "OpenCompound";
    public string closeCompoundAnime = "CloseCompound";

    void Start()
    {
        _compoundButton = GetComponent<Transform>();
        _childCompundText = _compoundButton.transform.GetChild(0);
    }

    private void OnMouseUpAsButton()
    {
        if (counter % 2 == 0)
        {
            _childCompundText.gameObject.SetActive(true);
            anim.Play(openCompoundAnime);
        }
        else
        {
            //_childCompundText.gameObject.SetActive(false);
            anim.Play(closeCompoundAnime);
        }
        counter++;
    }
}
