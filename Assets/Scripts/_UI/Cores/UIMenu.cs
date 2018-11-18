using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] UIDefine.Menu _MenuTag = UIDefine.Menu.UNDEFINED;
    public UIDefine.Menu MenuTag { get { return _MenuTag; } }

    Transform _displayTransform;

    protected void Awake()
    {
        
    }
    public void Open()
    {
        _displayTransform.gameObject.SetActive(true);
    }
    public void Close()
    {
        _displayTransform.gameObject.SetActive(false);
    }

    void OnValidate()
    {
        if(_displayTransform == null)
        {
            _displayTransform = this.transform.Find("Display");

            if(_displayTransform == null)
                Debug.LogError(_MenuTag.ToString() + " doesn't have Display object!!!");
            else
                Debug.Log(_MenuTag.ToString() + " attached Display object!!!");
        }
    }
}
