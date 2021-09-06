using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationStart : MonoBehaviour {

    void Awake()
    {
        if (Localization.Instance.currentLanguage == null)
            Localization.Instance.LoadFromJson("Assets/Languages/es_AR.json");
    }
}
