﻿namespace MediatrStudying.DItesting
{
    public interface IDItesting
    {
    string Logger(); 
    }
    public class DIclasses:IDItesting
    {
        public string Logger() { return "DI"; }
    }
}
