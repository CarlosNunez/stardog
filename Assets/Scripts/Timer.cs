using System;
using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    protected float timeOut = 2f;

    protected float timeLeft;

    public virtual void Update()
    {
        if (!DoCycle())
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Callback();
            timeLeft = timeOut;
        }
    }

    public virtual bool DoCycle()
    {
        return true;
    }

    public virtual void Callback()
    {
        Debug.Log("Never overwritten");
    }
}
