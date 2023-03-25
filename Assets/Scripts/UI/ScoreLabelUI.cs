using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreLabelUI : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;

    private void Start()
    {
        Game.Instance.OnScoreChanges += Game_OnScoreChanges;
    }

    private void Game_OnScoreChanges(object sender, Game.ScoringEventArgs e)
    {
        scoreLabel.text = e.value.ToString();
    }
}
