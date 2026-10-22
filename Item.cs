class Item
{
    public string Name { get; }
    public int SizeKb { get; }
    public string Extension { get; }

    public Item(string name, int sizeKb, string extension)
    {
        Name = name;
        SizeKb = sizeKb;
        Extension = extension;
    }
}
