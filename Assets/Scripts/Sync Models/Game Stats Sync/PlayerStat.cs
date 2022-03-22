using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerStatSync _playerStatSync;

    [SerializeField]
    public bool _isReady = default;
    public bool _previousIsReady = default;

    [SerializeField]
    public Color _weaponColor = default;
    public Color _previousWeaponColor = default;

    [SerializeField]
    public float _scoreStreak = default;
    public float _previousScoreStreak = default;

    [SerializeField]
    public float _trapsSent = default;
    public float _previousTrapsSent = default;

    [SerializeField]
    public int _currentLevel = default;
    public int _previousCurrentLevel = default;

    [SerializeField]
    public int _lives = default;
    public int _previousLives = default;

    //backup variable 1 used as isServer
    [SerializeField]
    public bool _backupVariable1 = default;
    public bool _previousBackupVariable1 = default;

    [SerializeField]
    public bool _backupVariable2 = default;
    public bool _previousBackupVariable2 = default;

    [SerializeField]
    public float _backupVariable3 = default;
    public float _previousBackupVariable3 = default;

    [SerializeField]
    public float _backupVariable4 = default;
    public float _previousBackupVariable4 = default;

    [SerializeField]
    public float _backupVariable5 = default;
    public float _previousBackupVariable5 = default;

    [SerializeField]
    public float _backupVariable6 = default;
    public float _previousBackupVariable6 = default;

    // Start is called before the first frame update
    void Awake()
    {
        _playerStatSync = GetComponent<PlayerStatSync>();
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
