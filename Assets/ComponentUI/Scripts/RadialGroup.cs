using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(RadialGroup))]
public class RadialGroupEditor : Editor
{
    RadialGroup instance;
    
    public override void OnInspectorGUI()
    {
        instance = (RadialGroup)target;

        EditorGUI.BeginChangeCheck();

        instance.centerObject = (GameObject)EditorGUI.ObjectField(EditorGUILayout.GetControlRect(), "Center ", instance.centerObject, typeof(GameObject), true);

        instance.padding = EditorGUILayout.Vector2Field("Padding", instance.padding);

        instance.autoSpread = EditorGUILayout.Toggle("Auto Spread", instance.autoSpread);
        if (!instance.autoSpread)
        {
            instance.spread = EditorGUILayout.FloatField("Spread Amount", instance.spread);
        }
        else
        {
            instance.CalculateSpread();
        }

        instance.startAngle = EditorGUILayout.IntSlider("Start Angle", instance.startAngle, 0, 359);
        instance.endAngle = EditorGUILayout.IntSlider("End Angle", instance.endAngle, 0, 359);

        instance.animate = EditorGUILayout.Toggle("Animate On Awake", instance.animate);

        if (GUILayout.Button("Preview"))
        {
            instance.BeginAnimate();
        }

        if (EditorGUI.EndChangeCheck())
        {
            instance.SetAlignment();
            instance.AlignChildren();
            instance.isDirty = true;
        }
    }
}
#endif

[ExecuteInEditMode]
public class RadialGroup: MonoBehaviour {


    public bool animate;

    GameObject[] children;
    int numChildren;

    public Vector2 padding;
    public float spread = 0f;
    public bool autoSpread;

    public int startAngle;
    public int endAngle;

    public GameObject centerObject;

    public bool isDirty;

    public void CalculateSpread()
    {
        spread = 50 + (20 * transform.childCount);
        if (spread >= 300)
        {
            spread = 300;
        }
    }

    private void OnEnable()
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onEnterRadial);
        spreadEnd = spread;
        isDirty = true;
        init = true;

        if (animate && Application.isPlaying)
        {
            BeginAnimate();
        }

    }

    public void OnDestroy()
    {
        //AudioManager.instance.PlayUISound(AudioManager.instance.uiSoundData.onExitRadial);
    }


    float spreadEnd;

    public void BeginAnimate()
    {
        LeanTween.value(gameObject, ChangeSpread, 0, spreadEnd, 0.5f);
    }

    public void ChangeSpread(float amount)
    {
        spread = amount;
    }


    private void Start()
    {
        isDirty = true;
    }

    void OnTransformChildrenChanged()
    {
        isDirty = true;
    }

    void OnTransformParentChanged()
    {
        isDirty = true;
    }
    /*
    IEnumerator Open(float angle)
    {
        yield return new WaitForSeconds(animFrequency);
        endAngle -= animAmplitude;
        AlignChildren();
        if (endAngle > angle)
        {
            StartCoroutine(Open(angle));
        }

    }*/

    void AlignChild(GameObject thisObj, int index)
    {

        float xPos = 0;
        float yPos = 0;

        float xAnch = 0.5f;
        float yAnch = 0.5f;

        if (numChildren > 1)
        {  //Calculate base position around center;
            //Mathf.PI()

            float endAngleOffset = 360 - endAngle;
            float angleInDegrees = (90 + startAngle) + ((endAngleOffset / numChildren) * index);
            float angleAsRadians = (angleInDegrees * Mathf.PI) / 180;
            xPos = Mathf.Cos(angleAsRadians) * spread;
            yPos = Mathf.Sin(angleAsRadians) * spread;
           
            xAnch = 1 - ((xPos / spread) / 2 + 0.5f);
            yAnch = (yPos / spread) / 2 + 0.5f;

        }

        

        thisObj.transform.localPosition = new Vector3(xPos + padding.x, yPos + padding.y);

        thisObj.GetComponent<RectTransform>().pivot = new Vector2(xAnch, yAnch);
    }

    public void SetAlignment()
    {
        if (autoSpread)
        {
            CalculateSpread();
        }

        
    }


    public void AlignChildren()
    {
        numChildren = 0;
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).gameObject.activeInHierarchy) {
                numChildren++;
            }
        }

        //Don't Account for the middle object
        if (centerObject != null)
        {
            numChildren -= 1;
        }

        int count = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeInHierarchy) { continue; }

            if (transform.GetChild(i).gameObject != centerObject)
            {

                AlignChild(transform.GetChild(i).gameObject,(count + 1));
            }
            else
            {
                AlignCenterObject();
            }

            count++;
        }
    }

    int initTimeout = 0;
    bool init = true;

    void AlignCenterObject()
    {
        centerObject.transform.localPosition = new Vector3(0, 0);

        centerObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

        if (numChildren == 1)
        {
            centerObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
            centerObject.transform.localPosition = new Vector3(0, -35);
        }
    }

    public void LateUpdate()
    {

        if (!isDirty) return;

        SetAlignment();
        AlignChildren();

        isDirty = false;
    }
}
