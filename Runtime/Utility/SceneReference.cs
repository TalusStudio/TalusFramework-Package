﻿using System.IO;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

namespace TalusFramework.Utility
{
	/// <summary>
	///		imported : https://github.com/NibbleByte/UnitySceneReference
	/// </summary>
	[System.Serializable]
	public class SceneReference : ISerializationCallbackReceiver
	{

#if UNITY_EDITOR
		// Reference to the asset used in the editor. Player builds don't know about SceneAsset.
		// Will be used to update the scene path.
		[SerializeField] private SceneAsset m_SceneAsset;

#pragma warning disable 0414 // Never used warning - will be used by SerializedProperty.
		// Used to dirtify the data when needed upon displaying in the inspector.
		// Otherwise the user will never get the changes to save (unless he changes any other field of the object / scene).
		[SerializeField] private bool m_IsDirty;
#pragma warning restore 0414
#endif

		// Player builds will use the path stored here. Should be updated in the editor or during build.
		// If scene is deleted, path will remain.
		[SerializeField]
		private string m_ScenePath = string.Empty;


		/// <summary>
		/// Returns the scene path to be used in the <see cref="UnityEngine.SceneManagement.SceneManager"/> API.
		/// While in the editor, this path will always be up to date (if asset was moved or renamed).
		/// If the referred scene asset was deleted, the path will remain as is.
		/// </summary>
		public string ScenePath
		{
			get
			{
#if UNITY_EDITOR
				AutoUpdateReference();
#endif

				return m_ScenePath;
			}

			set
			{
				m_ScenePath = value;

#if UNITY_EDITOR
				if (string.IsNullOrEmpty(m_ScenePath))
				{
					m_SceneAsset = null;
					return;
				}

				m_SceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(m_ScenePath);
				if (m_SceneAsset == null)
				{
					Debug.LogError($"Setting {nameof(SceneReference)} to {value}, but no scene could be located there.");
				}
#endif
			}
		}

		/// <summary>
		/// Returns the name of the scene without the extension.
		/// </summary>
		public string SceneName => Path.GetFileNameWithoutExtension(ScenePath);

		public bool IsEmpty => string.IsNullOrEmpty(ScenePath);

		public SceneReference() { }

		public SceneReference(string scenePath)
		{
			ScenePath = scenePath;
		}

		public SceneReference(SceneReference other)
		{
			m_ScenePath = other.m_ScenePath;

#if UNITY_EDITOR
			m_SceneAsset = other.m_SceneAsset;
			m_IsDirty = other.m_IsDirty;

			AutoUpdateReference();
#endif
		}

		public SceneReference Clone() => new SceneReference(this);

		public override string ToString()
		{
			return m_ScenePath;
		}

		[System.Obsolete("Needed for the editor, don't use it in runtime code!", true)]
		public void OnBeforeSerialize()
		{
#if UNITY_EDITOR
			AutoUpdateReference();
#endif
		}

		[System.Obsolete("Needed for the editor, don't use it in runtime code!", true)]
		public void OnAfterDeserialize()
		{
#if UNITY_EDITOR
			// OnAfterDeserialize is called in the deserialization thread so we can't touch Unity API.
			// Wait for the next update frame to do it.
			EditorApplication.update += OnAfterDeserializeHandler;
#endif
		}


#if UNITY_EDITOR
		private void OnAfterDeserializeHandler()
		{
			EditorApplication.update -= OnAfterDeserializeHandler;
			AutoUpdateReference();
		}

		private void AutoUpdateReference()
		{
			if (m_SceneAsset == null)
			{
				if (string.IsNullOrEmpty(m_ScenePath))
					return;

				SceneAsset foundAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(m_ScenePath);
				if (foundAsset)
				{
					m_SceneAsset = foundAsset;
					m_IsDirty = true;

					if (!Application.isPlaying)
					{
						// NOTE: This doesn't work for scriptable objects, hence the m_IsDirty.
						EditorSceneManager.MarkAllScenesDirty();
					}
				}
			}
			else
			{
				string foundPath = AssetDatabase.GetAssetPath(m_SceneAsset);
				if (string.IsNullOrEmpty(foundPath))
					return;

				if (foundPath != m_ScenePath)
				{
					m_ScenePath = foundPath;
					m_IsDirty = true;

					if (!Application.isPlaying)
					{
						// NOTE: This doesn't work for scriptable objects, hence the m_IsDirty.
						EditorSceneManager.MarkAllScenesDirty();
					}
				}
			}
		}
#endif
	}
}