using System.Collections.Generic;
using UnityEngine;

public delegate void Action();

// Attach me to an empty game object
public class MessagingManager : Singleton<MessagingManager> {

    public ScriptingObjects MyWaypoints;

    // public property for manager 
    private List<Action> subscribers = new List<Action>();

    void Awake() {
        Debug.Log("Messaging Manager Started");
    }

    //The Subscribe method for manager 
    public void Subscribe(Action subscriber) {
        Debug.Log("Subscriber registered");
        subscribers.Add(subscriber);
    }

    //The Unsubscribe method for manager 
    public void UnSubscribe(Action subscriber) {
        Debug.Log("Subscriber registered");
        subscribers.Remove(subscriber);
    }

    //Clear subscribers method for manager 
    public void ClearAllSubscribers() {
        subscribers.Clear();
    }
    public void Broadcast() {
        Debug.Log("Broadcast requested, No of Subscribers = " + subscribers.Count);
        foreach (var subscriber in subscribers) {
            subscriber();
        }
    }
}