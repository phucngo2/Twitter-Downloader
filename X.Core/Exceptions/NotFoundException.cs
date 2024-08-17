﻿namespace X.Core.Exceptions;

public abstract class NotFoundException : Exception
{
    public NotFoundException() : base("Not found!")
    {
        
    }

    public NotFoundException(string message) : base(message)
    {
        
    }
}
