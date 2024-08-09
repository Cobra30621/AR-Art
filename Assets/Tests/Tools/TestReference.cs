using Sirenix.OdinInspector;
using UnityEngine;

namespace Tests.Tools
{
    /// <summary>
    /// This class represents a test reference.
    /// </summary>
    public class TestReference : MonoBehaviour
    {
        /// <summary>
        /// The required UI video player prefab to be assigned in the Unity editor.
        /// </summary>
        [Required] public UI_VideoPlayer UIVideoPlayerPrefab;
    }
}