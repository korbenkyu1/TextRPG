using DG.Tweening;
using System;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    [SerializeField] Image DialogImage;
    [SerializeField] Text DialogText;
    [SerializeField] Button NextButton;
    [SerializeField] GameObject DialogBox;
    Tween typingTween;
    bool isTyping = false;
        
    public void Type(string text, Sprite image=null)
    {
        isTyping = true;
        NextButton.interactable = false;
        DialogText.text = "";
        typingTween = DialogText.DOText(text, text.Length * 0.05f).SetEase(Ease.Linear).OnComplete(() => {
            isTyping = false;
            NextButton.interactable = true;
        });
        if(image)
        {
            DialogImage.sprite = image;
        }
    }
    public void Skip()
    {
        if (!isTyping) return;
        NextButton.interactable = true;
        isTyping = false;
        typingTween.Complete();
    }
}
