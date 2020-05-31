using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceMesh.Framework.Search
{
    public class Property
    {

        public string Name { get; set; }
        public string Value { get; set; }
        public Operators Operator { get; set; }


    }

    public class Operators
    {

        public const string LT = "<";
        public const string EQ = "=";
        public const string LTE = "<=";
        public const string GT = ">";
        public const string GTE = ">=";

    }
}


