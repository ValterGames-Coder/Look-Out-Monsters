using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationSettings : MonoBehaviour
{
    public bool _isVibration;
    [SerializeField] private Toggle toggleVibration;
    public int _boolInt;

    void Start()
    {
        _boolInt = PlayerPrefs.GetInt("Vibrate");
        if(_boolInt == 1) toggleVibration.GetComponent<Toggle>().isOn = true;
        else if(_boolInt == 0) toggleVibration.GetComponent<Toggle>().isOn = false;
    }

    public void Vibration()
    {
      _isVibration = !_isVibration;
      if(_isVibration) _boolInt = 1;
      else _boolInt = 0;
      PlayerPrefs.SetInt("Vibrate", _boolInt);
    }
}
