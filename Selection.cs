using System.Collections.Generic;

static class Selection
{
    public static Item[] Apply(Item[] items)
    {
        var result = new List<Item>();
        foreach (Item item in items)
            if (item.Extension == "log")
                result.Add(item);
        return result.ToArray();
    }
}
