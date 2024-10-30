using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    Condition Health { get { return uiCondition.health; } }
    Condition Stemina { get { return uiCondition.stemina; } }

    bool isDead;
    bool isExhausted;

    private void Update()
    {
        UpdatePassive();
    }

    private void UpdatePassive()
    {
        isDead = Health.Add(Health.passiveValue * Time.deltaTime);
        isExhausted = Stemina.Add(Stemina.passiveValue * Time.deltaTime);
        if (isDead) { Die(); }
        if (isExhausted) { Exhausted(); }
    }

    public void Heal(float amount)
    {
        Health.Add(amount);
    }

    public void TakeDamage(float amount)
    {
        Health.Add(-amount);
    }

    public void UseStemina(float amount)
    {
        Stemina.Add(-amount);
    }

    private void Die()
    {
        Debug.Log("죽음!");
    }
    private void Exhausted()
    {
        Debug.Log("지침!");
    }
}