using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// 音量スライダー
/// </summary>
[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    /// <summary>
    /// オーディオミキサー
    /// </summary>
    [SerializeField]
    private AudioMixer _mixer = null;

    /// <summary>
    /// 音量パラメータ名
    /// </summary>
    [SerializeField]
    private string _parameterName = string.Empty;


    /// <summary>
    /// スライダー
    /// </summary>
    private Slider _slider = null;


    private void Reset()
    {
        var slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _mixer.GetFloat(_parameterName, out float mixerVolume);
        _slider.value = Db2Pa(mixerVolume);
        _slider.onValueChanged.AddListener((sliderValue) => _mixer.SetFloat(_parameterName, Pa2Db(sliderValue)));
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveAllListeners();
    }


    /// <summary>
    /// デシベル変換
    /// 0, 1, 10の音圧→-80, 0, 20のデシベル
    /// </summary>
    /// <param name="pa"></param>
    /// <returns></returns>
    private float Pa2Db(float pa)
    {
        pa = Mathf.Clamp(pa, 0.0001f, 10f);
        return 20f * Mathf.Log10(pa);
    }

    /// <summary>
    /// 音圧変換
    /// -80, 0, 20のデシベル→0, 1, 10の音圧
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    private float Db2Pa(float db)
    {
        db = Mathf.Clamp(db, -80f, 20f);
        return Mathf.Pow(10f, db / 20f);
    }
}
