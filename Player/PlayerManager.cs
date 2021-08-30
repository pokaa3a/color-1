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
        Player playerAlpha = Map.Instance.AddObject<Player>(new Vector2Int(0, 0));
        playerAlpha.id = PlayerId.Alpha;

        // Beta
        Player playerBeta = Map.Instance.AddObject<Player>(new Vector2Int(0, 2));
        playerBeta.id = PlayerId.Beta;

        // Gamma
        Player playerGamma = Map.Instance.AddObject<Player>(new Vector2Int(0, 4));
        playerGamma.id = PlayerId.Gamma;
    }
}
