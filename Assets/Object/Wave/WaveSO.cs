using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public struct WaveEvent
{
    [Tooltip("Event���� ��������")]
    public float eventDelay;

    [Tooltip("������ �� Prefab")]
    public GameObject enemyPrefab;

    [Tooltip("������ �� ������")]
    public int count;

    [Tooltip("Spawn �ֱ�")]
    public float spawnInterval;

    [Tooltip("������ �Լ�")]
    public UnityEvent doAction;
}

[CreateAssetMenu(fileName = "WaveSO", menuName = "SO/Wave")]
public class WaveSO : ScriptableObject
{
    [SerializeField] public List<WaveEvent> waveQueue;

}
