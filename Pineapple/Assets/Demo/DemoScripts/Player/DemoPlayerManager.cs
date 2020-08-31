using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pineapple
{
    public class DemoPlayerManager : MonoBehaviour
    {
        private DemoUI _demoUI;
        public DemoUI DemoUI { get { return _demoUI; } set { _demoUI = value; } }

        private DemoPlayer _demoPlayer;
        public DemoPlayer DemoPlayer { get { return _demoPlayer; } set { _demoPlayer = value; } }

        #region Singelton
        [SerializeField]
        private static DemoPlayerManager _instance;

        private static bool m_ShuttingDown = false;
        private static object m_Lock = new object();

        public static DemoPlayerManager Instance
        {
            get
            {
                if (m_ShuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(DemoPlayerManager) +
                        "' already destroyed. Returning null.");
                    return null;
                }

                lock (m_Lock)
                {
                    if (_instance == null)
                    {
                        // Search for existing instance.
                        _instance = (DemoPlayerManager)FindObjectOfType(typeof(DemoPlayerManager));

                        // Create new instance if one doesn't already exist.
                        if (_instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<DemoPlayerManager>();
                            singletonObject.name = typeof(DemoPlayerManager).ToString() + " (Singleton)";

                            // Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return _instance;
                }
            }
        }
        #endregion

        private void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }

        private void OnDestroy()
        {
            m_ShuttingDown = true;
        }

    }
}

