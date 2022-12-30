using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : MonoBehaviour
{

    public Cell right;
    public Cell down;
    public Cell left;
    public Cell up;

    public Fill fill;

    private void OnEnable()
    {

        GameController.slide += OnSlide;
        
    }
    private void OnDisable()
    {

        GameController.slide -= OnSlide;

    }

    private void OnSlide(string whatWasSent)
    {
        CellCheck();
        if (whatWasSent == "w")
        {
            if (up != null)
            {
                return;

            }
            Cell currentCell = this;
            SlideUp(currentCell);
        }
        if (whatWasSent == "d")
        {
            if (right != null)
            {
                return;

            }
            Cell currentCell = this;
            SlideRight(currentCell);

        }
        if (whatWasSent == "s")
        {

            if (down != null)
            {
                return;

            }
            Cell currentCell = this;
            SlideDown(currentCell);
        }
        if (whatWasSent == "a")
        {
            if (left != null)
            {
                return;

            }
            Cell currentCell = this;
            SlideLeft(currentCell);

        }

        GameController.ticker++;
        if (GameController.ticker == 4)
        {
            GameController.instance.SpawnFill();
        }
    }

    void SlideUp(Cell currentCell)
    {
        
        if (currentCell.down == null)
        {
            return;
        }

        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.down.fill != nextCell.fill)
                {
                    
                    nextCell.fill.transform.parent = currentCell.down.transform;
                    currentCell.down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }

        }
        else
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);

                
            }
        }

        if (currentCell.down== null)
        {
            return;
        }

        SlideUp(currentCell.down);

    }

    void SlideRight(Cell currentCell)
    {
        
        if (currentCell.left == null)
        {
            return;
        }

        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.left.fill != nextCell.fill)
                {
                    
                    nextCell.fill.transform.parent = currentCell.left.transform;
                    currentCell.left.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }

        }
        else
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);

                
            }
        }

        if (currentCell.left == null)
        {
            return;
        }

        SlideRight(currentCell.left);

    }

    void SlideDown(Cell currentCell)
    {
        
        if (currentCell.up == null)
        {
            return;
        }

        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.up.fill != nextCell.fill)
                {
                    
                    nextCell.fill.transform.parent = currentCell.up.transform;
                    currentCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }

        }
        else
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);

               
            }
        }

        if (currentCell.up == null)
        {
            return;
        }

        SlideDown(currentCell.up);

    }

    void SlideLeft(Cell currentCell)
    {
        
        if (currentCell.right == null)
        {
            return;
        }

        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.right.fill != nextCell.fill)
                {
                    
                    nextCell.fill.transform.parent = currentCell.right.transform;
                    currentCell.right.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }

        }
        else
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);

                
            }
        }

        if (currentCell.right == null)
        {
            return;
        }

        SlideLeft(currentCell.right);

    }


    void CellCheck()
    {
        if (fill == null)
        {
            return;
        }
        if (up !=null)
        {
            if (up.fill == null)
            {
                return;

            }
            if (up.fill.value == fill.value)
            {
                return;
            }
        }

        if (right != null)
        {
            if (right.fill == null)
            {
                return;

            }
            if (right.fill.value == fill.value)
            {
                return;
            }
        }
        if (down != null)
        {
            if (down.fill == null)
            {
                return;

            }
            if (down.fill.value == fill.value)
            {
                return;
            }
        }
        if (left != null)
        {
            if (left.fill == null)
            {
                return;

            }
            if (left.fill.value == fill.value)
            {
                return;
            }
        }

        GameController.instance.GameOverCheck();
    }

}
