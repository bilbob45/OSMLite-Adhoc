using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Infrastructure
{
    public class EnvironmentType
    {
        public enum EnvType
        {
            Development = 0,
            Production = 1
        }

        public EnvType Type
        {
            get{
                return EnvType.Production;
            }
            set
            {

            }
        }

        public EnvironmentType()
        {

        }
    }
}