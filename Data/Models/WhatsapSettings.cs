namespace TaskMasterApi.Data.Models;
public class WhatsapSettings
{
    public string Url { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string To { get; set; } = null!;
}

public class WhatsapMessage
{
    public string messaging_product { get; set; } = null!;
    public string to { get; set; } = null!;
    public string type { get; set; } = null!;
    public WhatsapTemplate template { get; set; } = null!;
}

public class WhatsapTemplate
{
    public string name { get; set; } = null!;
    public WhatsapTemplateLanguage language { get; set; } = null!;
    public List<WhatsapTemplateComponent> components { get; set; } = new List<WhatsapTemplateComponent>();
}

public class WhatsapTemplateLanguage
{
    public string code { get; set; } = null!;
}

public class WhatsapTemplateComponent
{
    public string type { get; set; } = null!;
    public string sub_type { get; set; } = null!;
    public int index { get; set; }
    public List<WhatsapTemplateParameter> parameters { get; set; } = new List<WhatsapTemplateParameter>();
}

public class WhatsapTemplateParameter
{
    public string type { get; set; } = null!;
    public string text { get; set; } = null!;
}
