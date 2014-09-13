using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicationManagerDA
{
    interface ServerDA
    {
        void OpenConnection();
        void CloseConnection();
    }
}
