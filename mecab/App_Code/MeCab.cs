using System.Collections.Generic;
using NMeCab;

public static class MeCabService
{
    private static MeCabTagger mecab { get; set; }
    static MeCabService()
    {
        mecab = MeCabTagger.Create();
    }
    public static List<MecabNode> parse(string text)
    {
        var node = mecab.ParseToNode(text);
        var nodes = new List<MecabNode>();
        while (node != null)
        {
            if (!node.Feature.StartsWith("BOS/EOS"))
            {
                nodes.Add(new MecabNode(node));
            }
            node = node.Next;
        }
        return nodes;
    }
}

public class MecabNode
{
    public string Word { get; set; }
    public string Part { get; set; }
    public string PartDetail1 { get; set; }
    public string PartDetail2 { get; set; }
    public string PartDetail3 { get; set; }
    public string StemType { get; set; }
    public string StemForm { get; set; }
    public string OriginalFormWord { get; set; }
    public string Kana { get; set; }
    public string Pronunciation { get; set; }
    public MecabNode() { }
    public MecabNode(MeCabNode node)
    {
        this.Word = node.Surface;
        var elms = node.Feature.Split(',');
        this.Part = elms[0] != "*" ? elms[0] : "";
        this.PartDetail1 = elms[1] != "*" ? elms[1] : "";
        this.PartDetail2 = elms[2] != "*" ? elms[2] : "";
        this.PartDetail3 = elms[3] != "*" ? elms[3] : "";
        this.StemType = elms[4] != "*" ? elms[4] : "";
        this.StemForm = elms[5] != "*" ? elms[5] : "";
        this.OriginalFormWord = elms[6] != "*" ? elms[6] : "";
        this.Kana = elms.Length > 7 ? elms[7] : "";
        this.Pronunciation = elms.Length > 8 ? elms[8] : "";
    }
}
