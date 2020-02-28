using System;

namespace SqlTable.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateAttribute : Attribute
    { }
}
