﻿namespace Ryze.Infrastructure.Exceptions;

public abstract class RyzeException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}