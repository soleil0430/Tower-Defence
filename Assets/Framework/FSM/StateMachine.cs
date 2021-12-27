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
    //Inspector창에서 보이기 위한 용도
    public List<State<T>> stateList = new List<State<T>>();
#endif
    protected Dictionary<string, State<T>> stateDictionary = new Dictionary<string, State<T>>();

    /// <summary>
    /// 현재 상태 검사
    /// </summary>
    /// <param name="stateName">상태</param>
    /// <returns>현재 상태가 stateName이 맞는가?</returns>
    public bool CheckState(string stateName)
    {
        return nowState.name == stateName;
    }

    /// <summary>
    /// Entity의 상태 객체 반환
    /// </summary>
    /// <param name="stateName">상태</param>
    /// <returns>상태가 있으면 상태, 없으면 null</returns>
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
        //Inspector창에서 보이기 위한 용도
        foreach(var pair in stateDictionary)
            stateList.Add(pair.Value);
#endif
    }

    /// <summary>
    /// StateMachine의 모든 State, Transition 초기화 하는 함수
    /// </summary>
    protected abstract void InitState();

    private void Update()
    {
        nowState.FSM_OnUpdate(entity);
        ChangeState(); //매 프레임 상태 전이 검사
    }

    void ChangeState()
    {
        //전이 여부 검사, 변화 없을 시 ""반환
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
