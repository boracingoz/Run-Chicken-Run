using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Abstracts.Utilities
{
    public abstract class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance  { get; private set; }

        protected void SingletonThisObject(T entity)
        {   
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

