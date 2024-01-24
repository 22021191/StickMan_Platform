using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _hepller : MonoBehaviour
{

    public static void ChangeAnim(string curName , Animator anim , string AnimName)
    {
        if (curName != AnimName)
        {
            anim.ResetTrigger(AnimName);
            curName = AnimName;
            anim.SetTrigger(AnimName);
        }
    }
}
