using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography
{
    public interface ISteganography<Tmsg, Tcontent>
    {
        Tmsg Hide(Tcontent Content, Tmsg OriginalMsg);
        Tcontent Find(Tmsg ModifiedMsg);
    }
}
