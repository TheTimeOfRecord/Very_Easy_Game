using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private float maxValue;
    [SerializeField] private float startValue;
    public float curValue;
    public float passiveValue;

    private void Awake()
    {
        Image[] images = GetComponentsInChildren<Image>();
        bar = images[1];
    }

    private void Start()
    {
        curValue = startValue;
    }

    private void BarUpdate()
    {
        bar.fillAmount = curValue / maxValue;
    }

    public bool Add(float amount)
    {
        curValue = curValue + amount;
        curValue = Mathf.Clamp(curValue, 0, maxValue);
        BarUpdate();
        return curValue == 0 ? true : false;
    }

    public void AddMax(float amount)
    {
        maxValue = maxValue + amount;
        Add(curValue);
    }
}
