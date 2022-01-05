using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ClockSettings : ScriptableObject
{
    public bool DisplaySeconds = true;

    public readonly float DefaultFontSize = 36;

    // (this could be cleaner but im literally making a clock)
    public ClockFont HourFont;
    public float HourFontSize = 36;
    public float HourSpacingDigits = 0;
    public float HourSpacingNumbers = 0;

    public ClockFont MinuteFont;
    public float MinuteFontSize = 36;
    public float MinuteSpacingDigits = 0;
    public float MinuteSpacingNumbers = 0;

    public ClockFont SecondsFont;
    public float SecondsFontSize = 36;
    public float SecondsSpacingDigits = 0;
    public float SecondsSpacingNumbers = 0;
}

