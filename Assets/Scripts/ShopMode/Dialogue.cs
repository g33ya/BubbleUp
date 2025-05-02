using UnityEngine;
using TMPro;
using System.Collections;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
//using UnityEditor.Rendering;
using System;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TMP_Text speakerText;
    public TMP_Text dialogueText;
    public Image portraitImage;
    public GameObject position1;
    public GameObject position2;
    public GameObject homeButton;
    public GameObject kitchenButton;
    public GameObject Character;
    public GameObject Character2;
    //public GameObject ElomarPosition;
    public string[] speaker;
    [TextArea]
    public string[] dialogueWords;
    public Sprite[] portrait;
    private bool dialogueActivated;
    //private bool isDrinkMade=false;
    private int step;
    private int currentScene;
    // void Start()
    // {
    //     isDrinkMade==false;
    // }
    void Start()
    {
        currentScene=SceneManager.GetActiveScene().buildIndex;
        speakerText.text=speaker[step];
            dialogueText.text=dialogueWords[step];
            portraitImage.sprite=portrait[step];
            step +=1;
    }
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
            if (currentScene==5){
            if (dialogueText.text=="Sure thing. Enjoy your day!"){
                position1.transform.position= new Vector3(-11.28f,1.154747f,0);
            }
            if (step==4){
                Character2.SetActive(true);
                position2.transform.position= new Vector3(-11.28f,1.154747f,0);
            }
            if (step==5){
                kitchenButton.SetActive(true);
            }
            }
            if (currentScene==1){
                if (step==4){
                    kitchenButton.SetActive(true);
            }
            }
            if (currentScene==3){
            if (step==9){
                //homeButton.SetActive(true);
                Character.SetActive(true);
                //position1.GetComponent<RectTransform>().anchoredPosition = new Vector2(537f, 97f);
            }
            if (step==10){
                kitchenButton.SetActive(true);
            }
            }
            if (currentScene==6){
                if (step==11){
                    homeButton.SetActive(true);
                    position1.transform.position= new Vector3(-11.28f,1.154747f,0);
                }
            }
            if (currentScene==7){
                if (step==3){
                    kitchenButton.SetActive(true);
                }
            }
            if (currentScene==8){
                if (step==4){
                Character.SetActive(true);
                }
                if (step==20){
                    kitchenButton.SetActive(true);
                }
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
