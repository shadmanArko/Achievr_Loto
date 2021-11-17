using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour
{

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f,
        minutesToDecimalOfHour = 1f / 60f;

    public Transform hours, minutes, seconds;
    public bool analog;

    void Update()
    {
        if (analog)
        {
            TimeSpan timespan = DateTime.Now.TimeOfDay;
            hours.localRotation = Quaternion.Euler(0f, 0f, ((float)timespan.TotalHours + (float)timespan.TotalMinutes * minutesToDecimalOfHour) * hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * secondsToDegrees);
        }
        else
        {
            DateTime time = DateTime.Now;
            hours.localRotation = Quaternion.Euler(0f, 0f, (time.Hour + time.Minute * minutesToDecimalOfHour) * hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * secondsToDegrees);
        }
    }
}