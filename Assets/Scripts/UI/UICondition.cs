using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stemina;
    private void Awake()
    {
        Condition[] conditions = GetComponentsInChildren<Condition>();
        health = conditions[0];
        stemina = conditions[1];
    }
    private void Start()
    {
        PlayerManager.Instance.Player.playerCondition.uiCondition = this;
    }
}
