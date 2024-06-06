using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace EckTechGames.AutoSave
{
    /// <summary>
    /// This static class registers the autosave methods when playmode state changes
    /// in the editor.
    /// </summary>
    [InitializeOnLoad]
    internal static class AutoSaveExtension
    {
        /// <summary>
        /// Static constructor that gets called when Unity fires up or recompiles the scripts.
        /// (triggered by the InitializeOnLoad attribute above)
        /// </summary>
        static AutoSaveExtension()
        {
            // Normally I'm against defensive programming, and this is probably
            // not necessary. The intent is to make sure we don't accidentally
            // subscribe to the playModeStateChanged event more than once.
            EditorApplication.focusChanged -= AutoSaveWhenFocusChanged;
            EditorApplication.focusChanged += AutoSaveWhenFocusChanged;

            EditorApplication.projectChanged -= AutoSaveWhenProjectChanged;
            EditorApplication.projectChanged += AutoSaveWhenProjectChanged;

            EditorApplication.hierarchyChanged -= AutoSaveWhenHierarchyChanged;
            EditorApplication.hierarchyChanged += AutoSaveWhenHierarchyChanged;

        }

        private static void AutoSaveWhenHierarchyChanged()
        {
            //Debug.Log("EckTechGames.AutoSaveWhenHierarchyChanged - Saving Scenes and Assets");

            // Save the open scenes
            _ = EditorSceneManager.SaveOpenScenes();
        }

        private static void AutoSaveWhenProjectChanged()
        {
            Debug.Log("EckTechGames.AutoSaveWhenProjectChanged - Saving Scenes and Assets");

            // Save the open scenes and any assets.
            _ = EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }

        private static void AutoSaveWhenFocusChanged(bool obj)
        {
            Debug.Log("EckTechGames.AutoSaveWhenFocusChanged - Saving Scenes and Assets");

            // Save the open scenes and any assets.
            _ = EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }

        /// <summary>
        /// This method saves open scenes and other assets when entering playmode. 
        /// </summary>
        /// <param name="playModeStateChange">The enum that specifies how the playmode is changing in the editor.</param>
        private static void AutoSaveWhenPlaymodeStarts(PlayModeStateChange playModeStateChange)
        {
            // If we're exiting edit mode (entering play mode)
            if (playModeStateChange == PlayModeStateChange.ExitingEditMode)
            {
                Debug.Log("EckTechGames.AutoSave - Saving Scenes and Assets");

                // Save the open scenes and any assets.
                _ = EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        }
    }
}