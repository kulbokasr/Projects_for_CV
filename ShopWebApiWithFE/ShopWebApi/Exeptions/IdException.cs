using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Exeptions
{
    [Serializable]
    public class IdException : Exception
    {
        public IdException(int id)
            : base(String.Format("Entered Id does not exsist. You entered: {0}", id))
        { }

    }
}
