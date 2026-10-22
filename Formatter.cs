static class Formatter
{
    public static string Format(Item item)
    {
        return item.Name + "; size=" + item.SizeKb;
    }
}
