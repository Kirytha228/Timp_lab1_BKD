static class Summary
{
    public static string Build(Item[] items)
    {
        int sumKb = 0;
        foreach (Item item in items)
            sumKb += item.SizeKb;
        return "SumKb: " + sumKb;
    }
}
