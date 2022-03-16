using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    public bool _isPlayersReadyToStartGame = default;
    public bool _previousIsPlayersReadyToStartGame = default;

    [SerializeField]
    public bool _isGameStarted = default;
    public bool _previousIsGameStarted = default;

    [SerializeField]
    public Color _colorWeaponPlayer1 = default;
    public Color _previousColorWeaponPlayer1 = default;

    [SerializeField]
    public Color _colorWeaponPlayer2 = default;
    public Color _previousColorWeaponPlayer2 = default;

    [SerializeField]
    public double _gameTimeElapsed = default;
    public double _previousGameTimeElapsed = default;

    [SerializeField]
    public int _streakPlayer1 = default;
    public int _previousStreakPlayer1 = default;

    [SerializeField]
    public int _streakPlayer2 = default;
    public int _previousStreakPlayer2 = default;

    [SerializeField]
    public int _trapsPlayer1 = default;
    public int _previousTrapsPlayer1 = default;

    [SerializeField]
    public int _trapsPlayer2 = default;
    public int _previousTrapsPlayer2 = default;

    [SerializeField]
    public int _levelPlayer1 = default;
    public int _previousLevelPlayer1 = default;

    [SerializeField]
    public int _levelPlayer2 = default;
    public int _previousLevelPlayer2 = default;

    [SerializeField]
    public int _livesPlayer1 = default;
    public int _previousLivesPlayer1 = default;

    [SerializeField]
    public int _livesPlayer2 = default;
    public int _previousLivesPlayer2 = default;

    [SerializeField]
    public int _gameWinner = default;
    public int _previousGameWinner = default;

    [SerializeField]
    public bool _backupVariable1 = default;
    public bool _previousBackupVariable1 = default;

    [SerializeField]
    public bool _backupVariable2 = default;
    public bool _previousBackupVariable2 = default;

    [SerializeField]
    public int _backupVariable3 = default;
    public int _previousBackupVariable3 = default;

    [SerializeField]
    public int _backupVariable4 = default;
    public int _previousBackupVariable4 = default;

    [SerializeField]
    public float _backupVariable5 = default;
    public float _previousBackupVariable5 = default;

    [SerializeField]
    public float _backupVariable6 = default;
    public float _previousBackupVariable6 = default;

    public GameLogicSync _gameLogicSync;

    // Start is called before the first frame update
    void Awake()
    {
        _gameLogicSync = GetComponent<GameLogicSync>();
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    // Remap function taken from unity forum (Don't know if we need this)
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
