using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    Image LoadingBar;
    public float slowdownLimitSeconds;
    public bool refill = false;

    [SerializeField] private float currentAmount;

    //[SerializeField] private float speed;
    public void Start()
    {
        LoadingBar = GetComponent<Image>();
    }
        
    void Update() {
        
        if (Input.GetKey(KeyCode.Z)) {
            currentAmount += Time.deltaTime;
            if (currentAmount <= slowdownLimitSeconds)
            {                
                Debug.Log((int)currentAmount % 60);
                LoadingBar.fillAmount = currentAmount / slowdownLimitSeconds;
                if (LoadingBar.fillAmount == 1)
                    Debug.Log("Finished at: " + (int)currentAmount % 60);
            }
        }
    }
    public bool Empty() {
        if (currentAmount >= slowdownLimitSeconds) return true;
        else return false;
    }
}
    
