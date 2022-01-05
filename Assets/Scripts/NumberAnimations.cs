using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface INumberAnimator
{
    void AbortCurrentAnimation();
    void PlayNewAnimation(int oldVal, int newVal, Number number);
}

public class NumberAnimationInstant : INumberAnimator
{
    public void AbortCurrentAnimation()
    { }

    public void PlayNewAnimation(int oldVal, int newVal, Number number)
    {
        number._onenessLabel.text = (newVal / 1 % 10).ToString();
        number._tensLabel.text = (newVal / 10 % 10).ToString();
    }
}

public class NumberAnimationTest : INumberAnimator
{
    public void AbortCurrentAnimation()
    { }

    public void PlayNewAnimation(int oldVal, int newVal, Number number)
    {
        int tens = (newVal / 10 % 10);
        int ones = (newVal / 1 % 10);

        if(number._tensLabel.text != tens.ToString())
            Clock.Instance.StartCoroutine(Animation(tens, number._tensLabel));

        if (number._onenessLabel.text != ones.ToString())
            Clock.Instance.StartCoroutine(Animation(ones, number._onenessLabel));
    }

    private IEnumerator Animation(int newVal, TextMeshPro label)
    {
        float animationDuration = 0.5f;
        float animationTime = 0;

        while (animationTime < animationDuration)
        {
            float scale = (animationTime / animationDuration);
            label.transform.localScale = new Vector3(scale, scale, 1);

            label.text = newVal.ToString();

            animationTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}