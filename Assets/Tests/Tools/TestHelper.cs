using UnityEngine;

namespace Tests.Tools
{
    /// <summary>
    /// This static class provides helper functions for testing purposes.
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Clears the current scene by destroying all game objects except for cameras.
        /// </summary>
        public static void ClearScene()
        {
            GameObject[] objects = Object.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objects)
            {
                if (obj == null) continue;
                if (obj.GetComponent<Camera>() == null)
                {
                    Object.DestroyImmediate(obj.gameObject);
                }
            }
        }

        /// <summary>
        /// Loads and retrieves the TestReference component from a "TestReference" prefab located in the Resources folder.
        /// </summary>
        /// <returns>The TestReference component of the loaded prefab.</returns>
        public static TestReference GetTestReference()
        {
            return ((GameObject)Resources.Load("TestReference", typeof(GameObject))).GetComponent<TestReference>();
        }
    }
}