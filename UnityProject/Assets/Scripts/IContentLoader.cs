using System;

public interface IContentLoader
{
    event Action Loaded;
    void Load();
    void Unload();
}