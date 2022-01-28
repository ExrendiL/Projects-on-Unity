using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCells : MonoBehaviour
{
    [SerializeField] private QuizSettings cells;

   
    [SerializeField] private Image artwork_image;
   
    private void Start()
    {

      
        artwork_image.sprite = cells.artwork;


    }


    }

    
        
       
    


