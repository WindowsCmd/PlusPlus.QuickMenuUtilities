using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QMUtils.API
{
    public class Page
    {
        /// <summary>
        /// The base page game object
        /// </summary>
        public GameObject pageGameObject { get; private set; }

        /// <summary>
        /// The title of the page, can be enabled and disabled.
        /// Set to an empty string if you dont want it enabled
        /// </summary>
        public string title { get; private set; }


    }
}
