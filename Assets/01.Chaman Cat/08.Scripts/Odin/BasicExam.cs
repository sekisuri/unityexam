using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
/*
* @author sekisuri
* http://ottcat.com
*/
public class BasicExam : MonoBehaviour 
{

    [FilePath(Extensions = ".unity")]
    public string ScenePath;

    [HideInInspector]
    public int NormallyVisible;

    [ShowInInspector]
    private bool normallyHidden;

    [ShowInInspector]
    public ScriptableObject Property { get; set; }
    [Button(ButtonSizes.Large)]
    public void SayHello()
    {
        Debug.Log("Hello button!");
    }

    [PreviewField, Required, AssetsOnly]
    public GameObject Prefab;

    [HideLabel, Required, PropertyOrder(-5)]
    public string Name { get; set; }

    [HorizontalGroup("Split", Width = 50), HideLabel, PreviewField(50)]
    public Texture2D Icon;

    [VerticalGroup("Split/Properties")]
    public string MinionName;

    [VerticalGroup("Split/Properties")]
    public float Health;

    [VerticalGroup("Split/Properties")]
    public float Damage;


    [LabelText("$IAmLabel")]
    public string IAmLabel;

    [ListDrawerSettings(
        CustomAddFunction = "CreateNewGUID",
        CustomRemoveIndexFunction = "RemoveGUID")]
    public List<string> GuidList;

    private string CreateNewGUID()
    {
        return "createNewGuid";
    }

    private void RemoveGUID(int index)
    {
        this.GuidList.RemoveAt(index);
    }


    [TabGroup("First Tab")]
    public int FirstTab;

    [ShowInInspector, TabGroup("First Tab")]
    public int SecondTab { get; set; }

    [TabGroup("Second Tab")]
    public float FloatValue;

    [TabGroup("Second Tab"), Button]
    public void Button()
    {

#if true
        Debug.Log("Click Button");
#endif

    }
}

