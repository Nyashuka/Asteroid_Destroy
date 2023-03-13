using Assets.Scripts.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Factory
{
    public class FactoryBase
    {

        protected void ReturnObjectToPool(IDestroyable destroyable)
        {
            if(destroyable is PoolableObject poolable)
            {

            }
        }
    }
}
