using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class SwitchNonARMode : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private bool _isOff = false;
    public bool isOff
    {
        get
        {
            return _isOff;
        }
    }

    [SerializeField]
    private RectTransform toggleIndicator;
    [SerializeField]
    private Image bgImage;
    [SerializeField]
    private Color onColor;
    [SerializeField]
    private Color offColor;
    private float offX;
    private float onX;
    [SerializeField]
    private float tweenTime = 0.25f;

    public delegate void ValueChange(bool value);
    public event ValueChange valueChange;


    // Start is called before the first frame update
    void Start()
    {
        offX = toggleIndicator.anchoredPosition.x;
        onX = bgImage.rectTransform.rect.width - toggleIndicator.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Toggle(bool value, bool changeMode = true)
    {
        if(value != isOff)
        {
            _isOff = value;

            ToggleColor(isOff);
            MoveIndicator(isOff);

            if(changeMode)
                SceneManager.LoadScene("Arena");
            // else
            //     SceneManager.LoadScene("ARMode");

            if(valueChange != null)
                valueChange(isOff);
        }
    }

    private void OnEnable() 
    {
        Toggle(isOff);
    }

    private void ToggleColor(bool value)
    {
        if(value)
            bgImage.DOColor(onColor, tweenTime);
        else
            bgImage.DOColor(offColor, tweenTime);
    }

    private void MoveIndicator(bool value)
    {
        if(value)
            toggleIndicator.DOAnchorPosX(onX, tweenTime);
        else
            toggleIndicator.DOAnchorPosX(offX, tweenTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Toggle(!isOff);
    }
}
