using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController
{
    private Number _number;
    private INumberAnimator _animator;

    private int _displayedValue;

    public NumberController(Number number)
    {
        _displayedValue = 0;
        _number = number;
        _animator = new AnimationInstant();

    }

    public void UpdateTime(int newValue)
    {
        if (_displayedValue == newValue)
            return;

        _animator.AbortCurrentAnimation();
        _animator.PlayNewAnimation(_displayedValue, newValue, _number);


        _displayedValue = newValue;
    }
}

public interface INumberAnimator
{
    void AbortCurrentAnimation();
    void PlayNewAnimation(int oldVal, int newVal, Number number);
}

public class AnimationInstant : INumberAnimator
{
    public void AbortCurrentAnimation()
    { }

    public void PlayNewAnimation(int oldVal, int newVal, Number number)
    {
        number._onenessLabel.text = (newVal / 1 % 10).ToString();
        number._tensLabel.text = (newVal / 10 % 10).ToString();
    }
}