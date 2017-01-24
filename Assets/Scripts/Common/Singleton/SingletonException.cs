using System;
using UnityEngine;

namespace SnowFrameWork
{
	public class SingletonException:Exception
    {
		public SingletonException( String msg ):base(msg)
        {
            Debug.Log( msg );
        }
    }
}
