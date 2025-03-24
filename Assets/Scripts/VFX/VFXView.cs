using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;

        [SerializeField] private List<VFXData> particleSystemMap;
        private ParticleSystem currentPlayingVFX;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(VFXType type, Vector2 positionToSet)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = positionToSet;

            foreach (VFXData item in particleSystemMap)
            {
                if (item.type == type)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    currentPlayingVFX = item.particleSystem;
                }
                else
                    item.particleSystem.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (currentPlayingVFX != null)
            {
                if (currentPlayingVFX.isStopped)
                {
                    currentPlayingVFX.gameObject.SetActive(false);
                    currentPlayingVFX = null;
                    controller.OnParticleEffectCompleted();
                    gameObject.SetActive(false);
                }
            }
        }

    }

    [Serializable]
    public struct VFXData
    {
        public VFXType type;
        public ParticleSystem particleSystem;
    }
}