using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public struct WaveEvent
{
    [Tooltip("Event시작 선딜레이")]
    public float eventDelay;

    [Tooltip("생성할 적 Prefab")]
    public GameObject enemyPrefab;

    [Tooltip("생성할 적 마리수")]
    public int count;

    [Tooltip("Spawn 주기")]
    public float spawnInterval;

    [Tooltip("실행할 함수")]
    public UnityEvent doAction;
}

[CreateAssetMenu(fileName = "WaveSO", menuName = "SO/Wave")]
public class WaveSO : ScriptableObject
{
    [SerializeField] public List<WaveEvent> waveQueue;

}
