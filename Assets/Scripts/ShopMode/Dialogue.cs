using UnityEngine;
using TMPro;
using System.Collections;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
//using UnityEditor.Rendering;
using System;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TMP_Text speakerText;
    public TMP_Text dialogueText;
    public Image portraitImage;
    public GameObject position1;
    public GameObject homeButton;
    public GameObject Character;
    public string[] speaker;
    [TextArea]
    public string[] dialogueWords;
    public Sprite[] portrait;
    private bool dialogueActivated;
    //private bool isDrinkMade=false;
    private int step;
    // void Start()
    // {
    //     isDrinkMade==false;
    // }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if (step>=speaker.Length){
                dialogueCanvas.SetActive(false);
               // step=0;
            }else{
 dialogueCanvas.SetActive(true);
            speakerText.text=speaker[step];
            dialogueText.text=dialogueWords[step];
            portraitImage.sprite=portrait[step];
            step +=1;
            if (step==9){
                homeButton.SetActive(true);
                Character.SetActive(true);
                //position1.GetComponent<RectTransform>().anchoredPosition = new Vector2(537f, 97f);
            }
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="NPC"){
            dialogueActivated=true;
        }
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     dialogueActivated=false;
    //     dialogueCanvas.SetActive(false);
    // }
    // public TextMeshProUGUI textComponent;
    // public string[] lines;
    // public float textSpeed;

    // private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     textComponent.text=string.Empty;
    //     StartDialogue();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetMouseButtonDown(0)){
    //         if(textComponent.text==lines[index]){
    //             NextLine();
    //         }else{
    //             StopAllCoroutines();
    //             textComponent.text=lines[index];
    //         }
    //     }
    // }

    // void StartDialogue(){
    //     index=0;
    //     StartCoroutine(TypeLine());
    // }
    // IEnumerator TypeLine(){
    //     foreach (char c in lines[index].ToCharArray()){
    //         textComponent.text+=c;
    //         yield return new WaitForSeconds(textSpeed);
    //     }
    // }
    // void NextLine(){
    //     if (index<lines.Length-1){
    //         index++;
    //         textComponent.text=string.Empty;
    //         StartCoroutine(TypeLine());
    //     }
    //     else{
    //         gameObject.SetActive(false);
    //     }
    // }
}
