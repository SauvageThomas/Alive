using UnityEngine;
using UnityEditor;

public class ConversationAsset {
    [MenuItem("Assets/Create/+Serialization/Conversation")]
    public static void CreateAsset() {
        CustomAssetUtility.CreateAsset<Conversation>();
    }
}