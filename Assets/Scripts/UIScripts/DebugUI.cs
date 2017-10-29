using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DebugUI : MonoBehaviour {
    public Text velocityText;
    public Text playerInAirText;

    [Range(1, 60)]
    public int frameAverage = 10;
    private List<Vector2> velocityList = new List<Vector2>();

    private void Awake()
    {
        
    }

    
    void Update () {
        PlayerStats playerStats = GameOverseer.Instance.player;

        velocityList.Add(playerStats.rigid.velocity);
        if (velocityList.Count >= frameAverage) SetVelocity();

        playerInAirText.text = "Player in air: " + playerStats.rigid.InAir;
	}

    private void SetVelocity()
    {
        Vector2 averageVelocity = Vector2.zero;
        foreach (Vector2 vec in velocityList)
        {
            averageVelocity += vec;
        }
        velocityList.Clear();

        averageVelocity /= frameAverage;
        
        velocityText.text = "Velocity: X - " + averageVelocity.x.ToString("0.00") + " Y - " + averageVelocity.y.ToString("0.00");
    }
}
