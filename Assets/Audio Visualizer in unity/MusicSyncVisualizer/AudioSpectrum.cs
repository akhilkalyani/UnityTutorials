using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

/// <summary>
/// Mini "engine" for analyzing spectrum data
/// Feel free to get fancy in here for more accurate visualizations!
/// </summary>
public class AudioSpectrum : MonoBehaviour
{

    AudioSource audioSource;
    public static float spectrumValue { get; private set; }
    public static float[] spectrumValues { get; private set; }
    private float[] m_audioSpectrum;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        m_audioSpectrum = new float[64];
    }

    private void Update()
    {
        audioSource.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Blackman);
        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValues = m_audioSpectrum;
            spectrumValue = m_audioSpectrum[0] * 1000;
        }
    }

}
