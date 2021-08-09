using System;
using Asteroids.View;
using Asteroids.View.Containers;

public class CustomRandom : ICustomRandom
{
    private Random _random = new Random();
    public int Next(int a)
    {
        return _random.Next(a);
    }

    public int Next(int a, int b)
    {
        if (a<=b)
        {
            return _random.Next(a,b);
        }
        else
        {
            return _random.Next(b, a);
        }
    }
}