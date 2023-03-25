using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public event EventHandler<ScoringEventArgs> OnScoreChanges;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public class ScoringEventArgs : EventArgs
    {
        public int value;
    }

    public void Score(int amount)
    {
        score += amount;

        UpdateValue();
    }

    private void UpdateValue()
    {
        OnScoreChanges?.Invoke(this, new ScoringEventArgs
        {
            value = score
        });
    }
}
