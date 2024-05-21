using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public float volumeKnob;
    // Start is called before the first frame update
    void Start()
    {
        volumeKnob = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        AudioController.Instance.AtualizarVolumeBG(volumeKnob);
    }
}
