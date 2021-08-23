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
        GameObject objectAlpha = new GameObject("playerAlpha");
        Player playerAlpha = objectAlpha.AddComponent<Player>() as Player;
        playerAlpha.Initialize(
            new Vector2Int(0, 0),
            new Vector2(Map.Instance.tileWidth, Map.Instance.tileHeight) * 0.7f,
            PlayerId.Alpha);
        players.Add(playerAlpha);

        // Beta
        GameObject objectBeta = new GameObject("playerBeta");
        Player playerBeta = objectBeta.AddComponent<Player>() as Player;
        playerBeta.Initialize(
            new Vector2Int(0, 2),
            new Vector2(Map.Instance.tileWidth, Map.Instance.tileHeight) * 0.7f,
            PlayerId.Beta);
        players.Add(playerBeta);

        // Gamma
        GameObject objectGamma = new GameObject("playerGamma");
        Player playerGamma = objectGamma.AddComponent<Player>() as Player;
        playerGamma.Initialize(
            new Vector2Int(0, 4),
            new Vector2(Map.Instance.tileWidth, Map.Instance.tileHeight) * 0.7f,
            PlayerId.Gamma);
        players.Add(playerGamma);
    }
}
