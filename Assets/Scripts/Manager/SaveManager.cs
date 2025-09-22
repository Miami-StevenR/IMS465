using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string SAVE_PATH = string.Empty;
    private PlayerState playerState;

    public void Awake()
    {
        SAVE_PATH = Path.Join(Application.persistentDataPath, "save.json");
        playerState = new PlayerState();
    }

    public void Save(CheckPointPayload checkpoint)
    {
        Debug.Log($"[Checkpoint] Position: {checkpoint.Position}, Rotation: {checkpoint.Rotation}");
        playerState.UpdateFromCheckpoint(checkpoint);
        var json = JsonUtility.ToJson(playerState.AsSerializable());
        File.WriteAllText(SAVE_PATH, json);
    }

    public PlayerState Load()
    {
        var json = File.ReadAllText(SAVE_PATH);
        var loadedPlayerState = JsonUtility.FromJson<SerializablePlayerState>(json);
        playerState = new PlayerState(loadedPlayerState);
        return playerState;
    }
}
