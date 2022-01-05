using System;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public static Clock Instance;

    [SerializeField]
    public ClockSettings Settings;

    [SerializeField]
    private Transform _hourTensAnchor,
        _hourOnenessAnchor,
        _minuteTensAnchor,
        _minuteOnenessAnchor,
        _secondsTensAnchor,
        _secondsOnenessAnchor;

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

        LoadSettings();
    }

    void Update()
    {
        SettingsUpdate();

        _hourController.UpdateTime(DateTime.Now.Hour);
        _minuteController.UpdateTime(DateTime.Now.Minute);
        _secondsController.UpdateTime(DateTime.Now.Second);
    }

    private void LoadSettings()
    {
        // Load file
    }

    /// <summary>
    /// Apply all settings
    /// </summary>
    private void SettingsUpdate()
    {
        // Show or hide seconds
        _secondsTensAnchor.localScale = Vector3.one * (Settings.DisplaySeconds ? 1 : 0);
        _secondsOnenessAnchor.localScale = Vector3.one * (Settings.DisplaySeconds ? 1 : 0);

        // Anchor positions
        float hourSizeRatio = (Settings.HourFontSize / Settings.DefaultFontSize);
        float minuteSizeRatio = (Settings.MinuteFontSize / Settings.DefaultFontSize);
        float secondsSizeRatio = (Settings.SecondsFontSize / Settings.DefaultFontSize);

        float hourDigitSpacing = (Settings.HourFont.BaseSpacing * hourSizeRatio) + (Settings.HourSpacingDigits * hourSizeRatio);
        float hourNumberSpacing = (Settings.HourFont.BaseSpacing * hourSizeRatio) + (Settings.HourSpacingNumbers * hourSizeRatio);

        float minuteDigitSpacing = (Settings.MinuteFont.BaseSpacing * minuteSizeRatio) + (Settings.MinuteSpacingDigits * hourSizeRatio);
        float minuteNumberSpacing = (Settings.MinuteFont.BaseSpacing * minuteSizeRatio) + (Settings.MinuteSpacingNumbers * hourSizeRatio);

        float secondsDigitSpacing = (Settings.SecondsFont.BaseSpacing * secondsSizeRatio) + (Settings.SecondsSpacingDigits * hourSizeRatio);
        float secondsNumberSpacing = (Settings.SecondsFont.BaseSpacing * secondsSizeRatio) + (Settings.SecondsSpacingNumbers * hourSizeRatio);

        if (Settings.DisplaySeconds)
        {
            // Hours
            _hourTensAnchor.localPosition = new Vector3()
            {
                x = -((minuteDigitSpacing / 2.0f) + (minuteNumberSpacing / 2.0f) + (hourNumberSpacing / 2.0f) + (hourDigitSpacing / 2.0f) + hourDigitSpacing)
            };
            _hourOnenessAnchor.localPosition = new Vector3()
            {
                x = -((minuteDigitSpacing / 2.0f) + (minuteNumberSpacing / 2.0f) + (hourNumberSpacing / 2.0f) + (hourDigitSpacing / 2.0f))
            };

            // Minutes
            _minuteTensAnchor.localPosition = new Vector3()
            {
                x = -(minuteDigitSpacing / 2.0f)
            };
            _minuteOnenessAnchor.localPosition = new Vector3()
            {
                x = (minuteDigitSpacing / 2.0f)
            };

            // Seconds
            _secondsTensAnchor.localPosition = new Vector3()
            {
                x = (minuteDigitSpacing / 2.0f) + (minuteNumberSpacing / 2.0f) + (secondsNumberSpacing / 2.0f) + (secondsDigitSpacing / 2.0f)
            };
            _secondsOnenessAnchor.localPosition = new Vector3()
            {
                x = (minuteDigitSpacing / 2.0f) + (minuteNumberSpacing / 2.0f) + (secondsNumberSpacing / 2.0f) + (secondsDigitSpacing / 2.0f) + secondsDigitSpacing
            };
        }
        else
        {
            float numberSpacing = (hourNumberSpacing / 2.0f) + (minuteNumberSpacing / 2.0f);
            // Hours
            _hourTensAnchor.localPosition = new Vector3()
            {
                x = -(hourNumberSpacing / 2.0f + hourDigitSpacing)
            };
            _hourOnenessAnchor.localPosition = new Vector3()
            {
                x = -hourNumberSpacing / 2.0f
            };

            // Minutes
            _minuteTensAnchor.localPosition = new Vector3()
            {
                x = minuteNumberSpacing
            };
            _minuteOnenessAnchor.localPosition = new Vector3()
            {
                x = minuteNumberSpacing + minuteDigitSpacing
            };
        }

        // Digit Properties

        // Hours
        {
            List<TextMeshPro> Labels = new List<TextMeshPro>();
            Labels.Add(_hoursNumber._tensLabel);
            Labels.Add(_hoursNumber._onenessLabel);
            Labels.AddRange(_hoursNumber._tensSecondaries);
            Labels.AddRange(_hoursNumber._onenessSecondaries);

            foreach (var label in Labels)
            {
                label.font = Settings.HourFont.FontAsset;
                label.fontSize = Settings.HourFontSize;
            }
        }

        // Minutes
        {
            List<TextMeshPro> Labels = new List<TextMeshPro>();
            Labels.Add(_minutesNumber._tensLabel);
            Labels.Add(_minutesNumber._onenessLabel);
            Labels.AddRange(_minutesNumber._tensSecondaries);
            Labels.AddRange(_minutesNumber._onenessSecondaries);

            foreach (var label in Labels)
            {
                label.font = Settings.MinuteFont.FontAsset;
                label.fontSize = Settings.MinuteFontSize;
            }
        }

        // Seconds
        {
            List<TextMeshPro> Labels = new List<TextMeshPro>();
            Labels.Add(_secondsNumber._tensLabel);
            Labels.Add(_secondsNumber._onenessLabel);
            Labels.AddRange(_secondsNumber._tensSecondaries);
            Labels.AddRange(_secondsNumber._onenessSecondaries);

            foreach (var label in Labels)
            {
                label.font = Settings.SecondsFont.FontAsset;
                label.fontSize = Settings.SecondsFontSize;
            }
        }
    }
}