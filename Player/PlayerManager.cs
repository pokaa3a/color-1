using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private const int numPlayers = 3;
    private List<Player> players;

    // Singleton
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerManager();
            }
            return _instance;
        }
    }

    private PlayerManager()
    {
        players = new List<Player>();
    }

    public void Create()
    {
        // Alpha
        Player playerAlpha = new Player(
            new Vector2Int(0, 0),
            new Vector2(Map.Instance.tileWidth, Map.Instance.tileHeight) * 0.7f,
            PlayerId.Alpha);
        players.Add(playerAlpha);

        // Beta
        Player playerBeta = new Player(
            new Vector2Int(0, 2),
            new Vector2(Map.Instance.tileWidth, Map.Instance.tileHeight) * 0.7f,
            PlayerId.Beta);
        players.Add(playerBeta);

        // Gamma
        Player playerGamma = new Player(
            new Vector2Int(0, 4),
            new Vector2(Map.Instance.tileWidth, Map.Instance.tileHeight) * 0.7f,
            PlayerId.Gamma);
        players.Add(playerGamma);
    }
}
