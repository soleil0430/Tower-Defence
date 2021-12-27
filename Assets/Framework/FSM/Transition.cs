using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct Transition<T> where T : MonoBehaviour
{
    //���̵� ����
    public State<T> nextState; 
    //���� ���� �˻�
    public Func<bool> doCheck;

    public Transition(State<T> _nextState)
    {
        nextState = _nextState;
        doCheck = null;
    }
}
