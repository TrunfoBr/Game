using UnityEngine;
using System.Collections;

public class Timer {
    private float time;
    private float elapsedTime = 0;

    public Timer() {
        Set(0);
    }

    public Timer(float time) {
        Set(time);
    }

    public void Reset() {
        elapsedTime = 0;
    }

    public void Run() {
        elapsedTime = elapsedTime + Time.deltaTime;
    }

    public bool IsOver() {
        return (elapsedTime >= time);
    }

    public void Set(float time) {
        this.time = time;
    }

    public float GetElapsedTime() {
        return elapsedTime;
    }
}
