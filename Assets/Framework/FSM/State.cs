using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class State<T> : ScriptableObject           //Inspectorâ���� ���� ������, 
                                 where T : MonoBehaviour
{
    public string name;
    public int tagHash; //=Animator.StringToHash("StateName");
    private List<Transition<T>> transitions = new List<Transition<T>>();

    public Action doEnter;
    public Action doUpdate;
    public Action doExit;

    #region FSM
    //On___ �Լ����� ������
    //�� State�� ���� ���� �� Callback �Լ����� ������
    public void FSM_OnEnter(T entity)
    {
        OnEnter(entity);
        doEnter?.Invoke();
    }
    public void FSM_OnUpdate(T entity)
    {
        OnUpdate(entity);
        doUpdate?.Invoke();
    }
    public void FSM_OnExit(T entity)
    {
        OnExit(entity);
        doExit?.Invoke();
    }
    #endregion

    #region Abstract
    protected abstract void OnEnter(T entity);
    protected abstract void OnUpdate(T entity);
    protected abstract void OnExit(T entity);
    #endregion

    public void AddTransition(Transition<T> transition) => transitions.Add(transition);

    public virtual string Translate(T entity)
    {
        foreach(var transition in transitions) {
            if (transition.doCheck())
                return transition.nextState.name;
        }

        return "";
    }
}
