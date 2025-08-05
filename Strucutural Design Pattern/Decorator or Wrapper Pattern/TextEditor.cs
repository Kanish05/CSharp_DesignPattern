/*
🧩 Problem Statement: Text Formatting System
You're building a text editor. You have a base text object that simply holds plain text.
Now, you want to add decorations like:

Bold

Italic

Underline

But you want to do this dynamically, without modifying the base class.

🧪 Requirements:
Create a IText interface with a method string GetContent().

Implement a concrete class PlainText that just returns raw text.

Create decorators for:

BoldDecorator → wraps text in <b>...</b>

ItalicDecorator → wraps text in <i>...</i>

UnderlineDecorator → wraps text in <u>...</u>

🎯 Example Usage:
csharp
Copy
Edit
IText text = new PlainText("Hello World");
text = new BoldDecorator(text);
text = new ItalicDecorator(text);
Console.WriteLine(text.GetContent());
✅ Expected Output:
css
Copy
Edit
<i><b>Hello World</b></i>
*/
using System;

public interface IText{
    string GetContent();
}

public class PlainText : IText{
    
    public string GetContent(){
        return "Hello world";
    }
}

public abstract class TextDecorator : IText {
    protected IText _text;
    
    public TextDecorator(IText text){
        _text = text;
    }
    
    public virtual string GetContent(){
        return _text.GetContent();
    }
}

public class BoldDecorator : TextDecorator{
    public BoldDecorator(IText text) : base(text){}
    
    public override string GetContent(){
        return "<b>"+ _text.GetContent() + "</b>";
    }
}

public class UnderlineDecorator : TextDecorator{
    public UnderlineDecorator(IText text) : base(text){}
    
    public override string GetContent(){
        return "<i>"+ _text.GetContent() + "</i>";
    }
}

public class ItalicDecorator : TextDecorator{
    public ItalicDecorator(IText text) : base(text){}
    
    public override string GetContent(){
        return "<u>"+ _text.GetContent() + "</u>";
    }
}

class Program{
    public static void Main(string[] args){
        IText text = new PlainText();
        Console.WriteLine(text.GetContent());
        text = new BoldDecorator(text);
        Console.WriteLine(text.GetContent());
        text = new ItalicDecorator(text);
        Console.WriteLine(text.GetContent());
        text = new UnderlineDecorator(text);
        Console.WriteLine(text.GetContent());
    }
}
