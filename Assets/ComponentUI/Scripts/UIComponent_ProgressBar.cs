using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class UIComponent_ProgressBar : UIComponent{

    enum ProgressBarType
    {
        Horizontal,
        Vertical
    }

    [SerializeField]
    bool mirror;

    [SerializeField]
    [Range(0,100)]
    int progress;

    [SerializeField]
    bool progressChangesColors;

    [SerializeField]
    Image fill;
    [SerializeField]
    Color fillColor;
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    bool showText;

    bool isHorizontal = true;

    public override void Awake()
    {
        UpdateProgressBarAlignment();
        if(text!=null && !showText && text.gameObject.activeInHierarchy)
        {
            text.gameObject.SetActive(false);
        }

        base.Awake();
    }


    /// <summary>
    /// Set progress based on a range.
    /// </summary>
    /// <param name="total"></param>
    /// <param name=""></param>
    public void SetProgressFromRange(int current, int max)
    {
        if (current == 0) { SetProgress(0); }

        float ratio = (max / current) * 100f;

        SetProgress(Mathf.RoundToInt(ratio));
    }
    
    public void SetProgress(int amount)
    {
        SetProgress(amount, false);
        if (progressChangesColors)
        {
            UpdateColors();
        }

    }

    Coroutine animating;

    public void SetProgress(int amount, bool animate)
    {
        if (amount > 100)
        {
            amount = 100;
        }



        if (animate)
        {
            loop = 0;
            if (animating != null)
            {
                StopCoroutine(animating);
            }
            animating = StartCoroutine(AnimateToNewProgessPosition(amount, Mathf.Abs(progress-amount)));
        }
        else
        {
            progress = amount;
            dirty = true;
        }
    }

    int loop;
    IEnumerator AnimateToNewProgessPosition(int amount, int difference)
    {
        dirty = true;

        int sum = difference / 10;
        
        yield return new WaitForSeconds(0.01f);
        if (loop >= 10)
        {
            progress = amount;
        }
        else {
            if (amount < progress)
            {
                progress -= sum;
                loop++;
                animating = StartCoroutine(AnimateToNewProgessPosition(amount, difference));
            }
            else if (amount > progress)
            {
                progress += sum;
                loop++;
                animating  = StartCoroutine(AnimateToNewProgessPosition(amount, difference));
            }
            else
            {
                progress = amount;
                

            }
        }

    }

    public int GetProgress() { return progress; }

    [SerializeField]
    ProgressBarType type;
    //Define if the progress bar is verticl, if it is, restructure the bar's logic.
    void UpdateProgressBarAlignment()
    {
        
        if (type == ProgressBarType.Vertical) { isHorizontal = false; }

        //Flips the pivot point based on its location;
        if (mirror)
        {
            fill.GetComponent<RectTransform>().pivot = isHorizontal ? new Vector2(1, 0.5f) : new Vector2(0.5f, 1);
        }
        else
        {
            fill.GetComponent<RectTransform>().pivot = isHorizontal ? new Vector2(0, 0.5f) : new Vector2(0.5f, 0);
        }

    }

    void TransformProgressBarFill()
    {
        float maxSize = 1f;
        float onePer = maxSize / 100;
  
        fill.transform.localScale = isHorizontal ? new Vector3(onePer * progress, 1, 1) : new Vector3(1, onePer * progress, 1);
    }

    bool dirty;
    public override void Update()
    {
        if (Application.isPlaying == false)
        {
            UpdateProgressBarAlignment();
            fill.color = fillColor;
            TransformProgressBarFill();
        }

        if (dirty)
        {
            TransformProgressBarFill();
            if (progressChangesColors)
            {
                UpdateColors();
            }
            dirty = false;
        }

    }

    public void SetColor(Color color)
    {
        fillColor = color;
        fill.color = fillColor;
    }

    public override void SkinObject()
    {
        //body.color = skinData.progressBarSkinBackgroundColor;
        fill.color = fillColor;

        //text.color = skinData.progressBarTextColor;

        if (progressChangesColors)
        {
            UpdateColors();
        }
    }


    void UpdateColors()
    {


        int colors = base.skinData.progressBarColors.Length;
        int difference = 100 / colors;
        int position = Mathf.RoundToInt(GetProgress() / difference);

        if (position <= 0) { position = 1; }
        

        fill.color = skinData.progressBarColors[position-1];

    }
}
