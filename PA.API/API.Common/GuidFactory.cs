using API.Common.Contracts;
using System;

namespace API.Common
{
    public class GuidFactory : IGuidFactory
    {
        private static GuidFactory _Instance = new GuidFactory();


        public static GuidFactory Instance
        {
            get
            {
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        public GuidFactory()
        {
        }

        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }

        public string GetGuidWithoutHyphen()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
