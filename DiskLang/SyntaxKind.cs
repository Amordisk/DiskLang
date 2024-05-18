namespace Tokens;

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
    EndOfFileToken,
    NumberExpression,
    BinaryExpression,
    ParenthesizedExpression,
}