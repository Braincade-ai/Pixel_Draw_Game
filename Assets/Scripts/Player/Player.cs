using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite dead;
    [SerializeField] private Sprite alive;

    private bool isDead;
    
    private bool nextState;
    
    private void Start()
    {
        isDead = true;
    }

    private void ChangeImage(){
        if(isDead) GetComponent<SpriteRenderer>().sprite = dead;
        else GetComponent<SpriteRenderer>().sprite = alive;
    }

    public void OnClick()
    { 
        isDead = !isDead;
        ChangeImage();
    }

    public void ActivateState()
    {
        isDead = !nextState;
        ChangeImage();
    }

    public void SetNextState(bool state){
        nextState = state;
    }

    public bool IsAlive() => !isDead;
}
