// See https://aka.ms/new-console-template for more information


enum SyntaxKind
{
    NumberToken,
    WhitespaceToken,
    PlusToken,
    MinusToken,
    StarToken,
    SlashToken,
    OpenParenthesisToken,
    CloseParenthesisToken,
    OpenBracketToken,
    CloseBracketToken,
    BadToken,
}
class SyntaxToken
{
    public SyntaxToken(SyntaxKind kind, int position, string text, object value)
    {
        Kind = kind;
        Position = position;
        Text = text;
        Value = value;
    }
    public SyntaxKind Kind { get; }
    public int Position { get; }
    public string Text { get; }
    public object Value { get; }

}
class Lexer
{
    private readonly string _text;
    private int _position;

    public Lexer(string text)
    {
        _text = text;
    }

    private char Current
    {
        get
        {
            if (_position >= _text.Length)
                return '\0';
            return _text[_position];
        }
    }

    private void Next()
    {
        _position++;
    }

    public SyntaxToken NextToken()
    {
        if (char.IsDigit(Current))
        {
            var start = _position;

            while (char.IsDigit(Current))
                Next();
            
            var length = _position - start;
            var text = _text.Substring(start, length);
            int.TryParse(text, out var value);
            return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
        }
        if (char.IsWhiteSpace(Current))
        {
            var start = _position;

            while (char.IsWhiteSpace(Current))
                Next();
            
            var length = _position - start;
            var text = _text.Substring(start, length);
            int.TryParse(text, out var value);
            return new SyntaxToken(SyntaxKind.WhitespaceToken, start, text, value);
        }
        if (Current == '+')
            return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
        else if (Current == '-')
            return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
        else if (Current == '*')
            return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
        else if (Current == '/')
            return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
        else if (Current == '(')
            return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
        else if (Current == ')')
            return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
        else if (Current == '[')
            return new SyntaxToken(SyntaxKind.OpenBracketToken, _position++, "[", null);
        else if (Current == ']')
            return new SyntaxToken(SyntaxKind.CloseBracketToken, _position++, "]", null);

        return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position - 1, 1), null);
    }
}