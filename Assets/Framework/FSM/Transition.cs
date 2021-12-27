using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct Transition<T> where T : MonoBehaviour
{
    //전이될 상태
    public State<T> nextState; 
    //전이 여부 검사
    public Func<bool> doCheck;

    public Transition(State<T> _nextState)
    {
        nextState = _nextState;
        doCheck = null;
    }
}
