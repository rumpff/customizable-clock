using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public static Clock Instance;
    [SerializeField] private TextMeshPro _hourTensLabel,
        _hourOnenessLabel,
        _minuteTensLabel,
        _minuteOnenessLabel,
        _secondsTensLabel,
        _secondsOnenessLabel;

    private Number _hoursNumber, _minutesNumber, _secondsNumber;
    private NumberController _hourController, _minuteController, _secondsController;

    void Start()
    {
        Instance = this;

        _hoursNumber = new Number(_hourTensLabel, _hourOnenessLabel);
        _minutesNumber = new Number(_minuteTensLabel, _minuteOnenessLabel);
        _secondsNumber = new Number(_secondsTensLabel, _secondsOnenessLabel);

        _hourController = new NumberController(_hoursNumber);
        _minuteController = new NumberController(_minutesNumber);
        _secondsController = new NumberController(_secondsNumber);
    }

    void Update()
    {
        _hourController.UpdateTime(DateTime.Now.Hour);
        _minuteController.UpdateTime(DateTime.Now.Minute);
        _secondsController.UpdateTime(DateTime.Now.Second);
    }
}