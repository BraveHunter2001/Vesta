﻿namespace Backend.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message):base(message) { }
    }
}
