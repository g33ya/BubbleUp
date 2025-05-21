using UnityEngine;

//This script adds Taro to the currently selected cup when the Taro carton is clicked

public class AddTaro : MonoBehaviour
{
    public Sprite taroOnlySprite;  //Taro Only
    public Sprite taroWithAloeSprite;  //Taro + Aloe
    public Sprite taroWithBobaSprite;  //Taro + Boba 
    public Sprite taroWithPoppinSprite;  //Taro + Poppin
    public AudioSource pour;

    private void OnMouseDown()
    {
        GameObject cup = CupButtonSpawner.currentCup;

        // Only proceed if a cup is actually selected
        if (cup != null)
        {
            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();

            if (sr != null && state != null)
            {
                //cup already has Boba, then add Taro so now the cup changes to Sprite Taro + Boba
                if (state.hasBoba)
                {
                    sr.sprite = taroWithBobaSprite;
                    pour.Play();
                }
                //cup already has Aloe, then add Taro so now the cup changes to Sprite Taro + Aloe
                else if (state.hasAloe)
                {
                    sr.sprite = taroWithAloeSprite;
                    pour.Play();

                }
                //cup already has Poppin, then add Taro so now the cup changes to Sprite Taro + Poppin
                else if (state.hasPoppin)
                {
                    sr.sprite = taroWithPoppinSprite;
                    pour.Play();
                }
                else
                {
                    sr.sprite = taroOnlySprite;
                    pour.Play();
                }
                //mark that taro was added
                state.hasTaro = true;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
