using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Slider uiSlider;
    public UnityAction OnPointerDownEvent;
    public UnityAction OnPointerUpEvent;
    public UnityAction<float> OnPointerDragEvent;

    private void Awake() {
        
        uiSlider = GetComponent<Slider>();
        uiSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownEvent?.Invoke();
        OnPointerDragEvent?.Invoke(uiSlider.value);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUpEvent?.Invoke();

        uiSlider.value = 0f;
    }

    private void OnSliderValueChanged(float value){

        OnPointerDragEvent?.Invoke(value);
    }

    private void OnDestroy(){

        uiSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}
