using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PineappleException : Exception
{
    public PineappleException()
    {
    }

    public PineappleException(string message) : base(message)
    {
    }

    public PineappleException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected PineappleException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
