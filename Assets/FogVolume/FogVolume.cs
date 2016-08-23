/*CHANGE LOG
 * Added cute icon
 * Hack to avoid bug that breaks the effect when VolumeSize.x = VolumeSize.y = VolumeSize.z
 * fixed build warnings
 * added noise color tweaks (contrast, intensity)
 * fixed data update. Effect won't dissapear anymore in editor mode
 * Inscattering is now inside Volume boundings
 * Fixed Noise intensity & contrast
 * Added Noise sampling parameter (quality)
 * Public access to visibility (used by FoggyLights)
 * Shader variants fixes
 * Copy-paste will create a new material now
 * Gradients first implementation
 * */

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

    [ExecuteInEditMode]

    public class FogVolume : MonoBehaviour
    {
        GameObject FogVolumeGameObject;
        public Camera ForwardRenderingCamera;

        [HideInInspector]
        public Material FogMaterial;
        [SerializeField]
        Color
                InscatteringColor = Color.white, FogColor = new Color(.5f, .6f, .7f, 1);

        public float Visibility = 5;
        [Range(-1, 1)]
        public float InscatteringShape = 0;
        public float InscatteringIntensity = 2, InscatteringStartDistance = 400, InscatteringTransitionWideness = 1, _3DNoiseScale = 300, _3DNoiseStepSize = 50;
       

        public Texture3D _NoiseVolume = null;

        [Range(0f, 10)]
        public float NoiseIntensity = 1;

        [Range(0f, 1f)]
        public float NoiseContrast = 0;

        [SerializeField]
        Light
                Sun;


        [SerializeField]
        int
                DrawOrder = 0;
        public Texture2D Gradient;
        [SerializeField]
        bool EnableGradient = false, EnableInscattering = false, EnableNoise = false;

        public Vector4 Speed = new Vector4(0, 0, 0, 0);
        public Vector4 Stretch = new Vector4(0, 0, 0, 0);
        
        #if UNITY_EDITOR
        bool HideWireframe = true;
        #endif

        public float GetVisibility()
        {
            return Visibility;
        }

        void CreateMaterial()
        {            
            FogMaterial = new Material(Shader.Find("Hidden/FogVolume"));
            FogMaterial.name = "Fog Material";
            FogMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
        void SetCameraDepth()
        {
            if (ForwardRenderingCamera)
                ForwardRenderingCamera.depthTextureMode |= DepthTextureMode.Depth;
        }
        void OnEnable()
        {                        
            CreateMaterial();
            SetCameraDepth();
            FogVolumeGameObject = this.gameObject;
            FogVolumeGameObject.renderer.sharedMaterial = FogMaterial;
            ToggleKeyword();     
            
        }

        static public void Wireframe(GameObject obj, bool Enable)
        {
#if UNITY_EDITOR
            EditorUtility.SetSelectedWireframeHidden(obj.renderer, Enable);
#endif
        }

        void Update()
        {
#if UNITY_EDITOR
            Visibility = Mathf.Max(0.01f, Visibility);
            _3DNoiseStepSize = Mathf.Max(1, _3DNoiseStepSize);          
            InscatteringIntensity = Mathf.Max(0, InscatteringIntensity);
            NoiseIntensity = Mathf.Max(0, NoiseIntensity);
            InscatteringTransitionWideness = Mathf.Max(1, InscatteringTransitionWideness);
            InscatteringStartDistance = Mathf.Max(0, InscatteringStartDistance);
            if (_NoiseVolume == null)
                EnableNoise = false;
#endif
        }

        void OnWillRenderObject()
        {
#if UNITY_EDITOR
            ToggleKeyword();
            Wireframe(FogVolumeGameObject, HideWireframe);
#endif

            FogMaterial.SetColor("_Color", FogColor);
            FogMaterial.SetColor("_InscatteringColor", InscatteringColor);

            if (Sun)
            {
                FogMaterial.SetFloat("_InscatteringIntensity", InscatteringIntensity);
                FogMaterial.SetVector("L", -Sun.transform.forward);
                FogMaterial.SetFloat("InscatteringShape", InscatteringShape);
                FogMaterial.SetFloat("InscatteringTransitionWideness", InscatteringTransitionWideness);
            }

            if (EnableNoise && _NoiseVolume)
            {

                Shader.SetGlobalTexture("_NoiseVolume", _NoiseVolume);                
                FogMaterial.SetFloat("gain", NoiseIntensity);
                FogMaterial.SetFloat("threshold", NoiseContrast * 0.5f);
                FogMaterial.SetFloat("_3DNoiseScale", _3DNoiseScale * .001f);
                FogMaterial.SetFloat("_3DNoiseStepSize", _3DNoiseStepSize * .001f );
                FogMaterial.SetVector("Speed", Speed);
                FogMaterial.SetVector("Stretch", new Vector4(1, 1, 1, 1) + Stretch * .01f);
                //FogMaterial.SetInt("_NoiseSamples", _NoiseSamples);
            }

            if(Gradient !=null)
                FogMaterial.SetTexture("_Gradient", Gradient);           

            FogMaterial.SetFloat("InscatteringStartDistance", InscatteringStartDistance);
            Vector3 VolumeSize = FogVolumeGameObject.transform.localScale;
            //bug fix. If the 3 axes values are equal, something gets broken :/
            transform.localScale = new Vector3((float)decimal.Round((decimal)VolumeSize.x, 2), VolumeSize.y, VolumeSize.z);
            FogMaterial.SetVector("_BoxMin", VolumeSize * -.5f);
            FogMaterial.SetVector("_BoxMax", VolumeSize * .5f);

            FogMaterial.SetFloat("_Visibility", Visibility);
            renderer.sortingOrder = DrawOrder;

            //Matrix4x4 viewMat = Camera.main.worldToCameraMatrix;
            //Matrix4x4 projMat = GL.GetGPUProjectionMatrix(Camera.main.projectionMatrix, false);
            //Matrix4x4 viewProjMat = (projMat * viewMat);
            //Shader.SetGlobalMatrix("_ViewProjInv", viewProjMat.inverse);            
            
        }

        void ToggleKeyword()
        {
            if (FogMaterial)
            {
                if (EnableNoise && SystemInfo.supports3DTextures)
                    FogMaterial.EnableKeyword("_FOG_VOLUME_NOISE");
                else
                    FogMaterial.DisableKeyword("_FOG_VOLUME_NOISE");

                if (EnableInscattering && Sun)
                    FogMaterial.EnableKeyword("_FOG_VOLUME_INSCATTERING");
                else
                    FogMaterial.DisableKeyword("_FOG_VOLUME_INSCATTERING");

                if (EnableGradient && Gradient != null)
                    FogMaterial.EnableKeyword("_FOG_GRADIENT");
                else
                    FogMaterial.DisableKeyword("_FOG_GRADIENT");
                
            }
        }
    }
