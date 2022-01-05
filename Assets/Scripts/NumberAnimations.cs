using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
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

public class NumberAnimationSlide : INumberAnimator
{
    public void AbortCurrentAnimation()
    { }

    public void PlayNewAnimation(int oldVal, int newVal, Number number)
    {
        int tensOld = (oldVal / 10 % 10);
        int onesOld = (oldVal / 1 % 10);

        int tensNew = (newVal / 10 % 10);
        int onesNew = (newVal / 1 % 10);

        if (number._tensLabel.text != tensNew.ToString())
            Clock.Instance.StartCoroutine(Animation(tensOld, tensNew, number._tensLabel, number._tensSecondaries[1]));

        if (number._onenessLabel.text != onesNew.ToString())
            Clock.Instance.StartCoroutine(Animation(onesOld, onesNew, number._onenessLabel, number._onenessSecondaries[1]));
    }

    private IEnumerator Animation(int oldVal, int newVal, TextMeshPro labelMain, TextMeshPro labelSecond)
    {
        float animationDuration = 0.5f;
        float animationTime = 0;
        float charHeight = labelMain.renderedHeight;

        labelSecond.text = oldVal.ToString();
        labelMain.text = newVal.ToString();

        labelSecond.transform.localPosition = new Vector3(0, charHeight);

        while (animationTime < animationDuration)
        {
            float t = (animationTime / animationDuration);
            float y = (t * charHeight) - charHeight;

            labelMain.alpha = t;
            labelSecond.alpha = 1 - t;

            labelMain.transform.localPosition = new Vector3(0, y);

            animationTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        // Clean up
        labelMain.alpha = 1;
        labelSecond.alpha = 0;
        labelMain.transform.localPosition = Vector3.zero;
    }
}