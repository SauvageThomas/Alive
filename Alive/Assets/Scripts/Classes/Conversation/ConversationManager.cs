using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : Singleton<ConversationManager> {

    //Is there a converastion going on
    bool talking = false;

    //The current line of text being displayed
    ConversationEntry currentConversationLine;

    //the Canvas Group for the dialog box
    public CanvasGroup dialogBox;

    //the image holder
    public Image imageHolder;

    //the text holder
    public Text textHolder;

    //Guarantee this will always be a singleton only -  
    //can't use the constructor! 
    protected ConversationManager() { }

    IEnumerator DisplayConversation(Conversation conversation) {
        talking = true;
        foreach (var conversationLine in conversation.ConversationLines) {
            currentConversationLine = conversationLine;
            textHolder.text = currentConversationLine.ConversationText;
            imageHolder.sprite = currentConversationLine.DisplayPic;
            yield return new WaitForSeconds(3);
        }
        talking = false;
    }

    void OnGUI() {
        if (talking) {
            dialogBox.alpha = 1;
            dialogBox.blocksRaycasts = true;
        }
        else {
            dialogBox.alpha = 0;
            dialogBox.blocksRaycasts = false;
        }
    }



    public void StartConversation(Conversation conversation) {
        dialogBox = GameObject.Find("Dialog Box").GetComponent<CanvasGroup>();
        imageHolder = GameObject.Find("Speaker Image").GetComponent<Image>();
        textHolder = GameObject.Find("Dialog Text").GetComponent<Text>();
        //Start displying the supplied conversation
        if (!talking) {
            StartCoroutine(DisplayConversation(conversation));
        }
    }

}