using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class StateMachine<T> : MonoBehaviour 
                                        where T : MonoBehaviour
{
    [DisableField] protected T entity;
    [DisableField] public State<T> nowState;
#if UNITY_EDITOR
    //Inspectorâ���� ���̱� ���� �뵵
    public List<State<T>> stateList = new List<State<T>>();
#endif
    protected Dictionary<string, State<T>> stateDictionary = new Dictionary<string, State<T>>();

    /// <summary>
    /// ���� ���� �˻�
    /// </summary>
    /// <param name="stateName">����</param>
    /// <returns>���� ���°� stateName�� �´°�?</returns>
    public bool CheckState(string stateName)
    {
        return nowState.name == stateName;
    }

    /// <summary>
    /// Entity�� ���� ��ü ��ȯ
    /// </summary>
    /// <param name="stateName">����</param>
    /// <returns>���°� ������ ����, ������ null</returns>
    public State<T> GetState(string stateName)
    {
        if (stateDictionary.TryGetValue(stateName, out State<T> state))
            return state;
        else
            return null;
    }

    private void Awake()
    {
        InitState();
        entity = GetComponent<T>();

#if UNITY_EDITOR
        //Inspectorâ���� ���̱� ���� �뵵
        foreach(var pair in stateDictionary)
            stateList.Add(pair.Value);
#endif
    }

    /// <summary>
    /// StateMachine�� ��� State, Transition �ʱ�ȭ �ϴ� �Լ�
    /// </summary>
    protected abstract void InitState();

    private void Update()
    {
        nowState.FSM_OnUpdate(entity);
        ChangeState(); //�� ������ ���� ���� �˻�
    }

    void ChangeState()
    {
        //���� ���� �˻�, ��ȭ ���� �� ""��ȯ
        string key = nowState.Translate(entity);

        if (stateDictionary.ContainsKey(key))
        {
            State<T> nextState = stateDictionary[key];

            nowState.FSM_OnExit(entity);
            nextState.FSM_OnEnter(entity);

            nowState = nextState;
        }
    }
}
