using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<WaveSO> wavesSO;
    public int waveLevel = 1;

    public bool NextWave()
    {
        waveLevel++;
        if (waveLevel >= wavesSO.Count)
        {
            return false;
        }
        else
        {
            PlayWaveEvent();
            return true;
        }
    }

    public void PlayWaveEvent()
    {
        WaveSO nowWave = wavesSO[waveLevel];


    }
}
