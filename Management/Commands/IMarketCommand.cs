using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperStoreEntities.Management.Commands
{
    internal interface IMarketCommand
    {   
        void Execute();
        void Undo() { }
    }
}
