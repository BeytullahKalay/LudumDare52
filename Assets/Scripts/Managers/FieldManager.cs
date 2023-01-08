using System.Collections.Generic;
using FieldScripts;
using UnityEngine;

namespace Managers
{
    public class FieldManager : MonoBehaviour
    {
        #region Singleton

        public static FieldManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
        
        
        public List<Field> fields = new List<Field>();

        public Field GetLootableField()
        {
            foreach (var field in fields)
            {
                if (!field.State.IsOpen) continue;

                if (field.State.IsEmpty)
                {
                    return field;
                }
            }

            return null;
        }
    }
}
