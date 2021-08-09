using System.Collections.Generic;

public class ContentManager 
{
    private Dictionary<ContentGroups, List<IContentLoader>> _contentLoaders = new Dictionary<ContentGroups, List<IContentLoader>>();

    public void Awake()
    {
        _contentLoaders.Add(ContentGroups.UI,new List<IContentLoader>());
        _contentLoaders.Add(ContentGroups.Game,new List<IContentLoader>());
    }

    public void GroupUnload(ContentGroups group)
    {
        foreach (var loader in _contentLoaders[group])
        {
            loader.Unload();
        }
        _contentLoaders[group].Clear();
    }

    public ContentLoader<T> Create<T>(ContentGroups groups, string key)
    {
        var loader = new ContentLoader<T>(key);
        _contentLoaders[groups].Add(loader);
        return loader;
    }
}