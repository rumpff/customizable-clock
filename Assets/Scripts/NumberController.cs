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
        _displayedValue = -1;
        _number = number;
        _animator = new NumberAnimationSlide();

    }

    public void UpdateSettings()
    {

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

