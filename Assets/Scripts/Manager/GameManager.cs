using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour, IObservableListener
{
    [SerializeField]
    private List<CheckPoint> checkpoints = new();
    [SerializeField]
    private SaveManager saveManager;
    [SerializeField]
    private GameObject player;

    void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CacheCheckpoints();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Load();
        }
    }

    public void OnReceieveMessage(object sender, ObservablePayload payload)
    {
        switch (payload.Subject)
        {
            case Subject.Checkpoint:
                var checkpointPayload = (CheckPointPayload)payload;
                Save(checkpointPayload);
                break;
            default:
                break;
        }
    }

    private void Save(CheckPointPayload checkpoint)
    {
        saveManager.Save(checkpoint);
    }

    private void Load()
    {
        var playerState = saveManager.Load();
        var _player = player.GetComponent<Player>();
        _player.SetPosition(playerState.Position);
        _player.SetRotation(playerState.Rotation);
    }

    private void CacheCheckpoints()
    {
        var checkpoints = FindObjectsByType<CheckPoint>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        this.checkpoints.AddRange(checkpoints);
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.AddListener(this);
        }
    }
}
