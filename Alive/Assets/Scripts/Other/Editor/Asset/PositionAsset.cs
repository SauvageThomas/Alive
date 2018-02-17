using UnityEngine;
using UnityEditor;

public class PositionManager : MonoBehaviour {
    [MenuItem("Assets/Create/+Serialization/Position")]
    public static void CreateAsset() {
        CustomAssetUtility.CreateAsset<ScriptingObjects>();
    }

    public static PositionManager ReadPositionsFromAsset(string Name) {
        string path = "/"; object o = Resources.Load(path + Name);
        PositionManager retrievedPositions = (PositionManager)o;
        return retrievedPositions;
    }
}