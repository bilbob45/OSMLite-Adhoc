using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Infrastructure
{
    public interface IStringUtility
    {
        String Encode(string text);
        String Decode(string text);
    }
}