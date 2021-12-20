/*
  Demonstration of interpreter pattern.

  Here we will create an interpreter which will take a string of arithmetic expression, interprete it into logical means
  and evaluate it.
*/

namespace DesignPatterns.Interpreters;

enum Dummy { }

class Operation
{
  public enum Type { Add, Subtract, Multiply, Divide, Module }
  public int Left { get; set; }
  public int Right { get; set; }
  public Type OperationType { get; set; }
  public int Value
  {
    get
    {
      switch (OperationType)
      {
        case Type.Add:
          return Left + Right;
        case Type.Subtract:
          return Left - Right;
        case Type.Multiply:
          return Left * Right;
        case Type.Divide:
          return Left / Right;
        case Type.Module:
          return Left % Right;
        default:
          throw new ArgumentNullException();
      }
    }
  }
}

class Token
{
  public enum Type { Integer, Plus, Minus, Asterisk, Percent, Lparen, Rparen, Slash }
  public Type TokenType { get; private set; }
  public string Text { get; private set; }
  public Token(string text, Type type)
  {
    Text = text;
    TokenType = type;
  }

  public override string ToString()
  {
    return $"Type: {TokenType}, Text: {Text}";
  }
}

class Interpreter
{
  public string Evaluate(string expression)
  {
    var tokens = Lexer(expression);
    var value = Parser(tokens);
    return $"Input: {expression}, Expression: {string.Join(string.Empty, tokens.Select(token => token.Text))}, Output: {value}";
  }
  public List<Token> Lexer(string expression)
  {
    List<Token> tokens = new List<Token>();
    for (int i = 0; i < expression.Length; i++)
    {
      switch (expression[i])
      {
        case '+':
          tokens.Add(new Token("+", Token.Type.Plus));
          break;
        case '-':
          tokens.Add(new Token("-", Token.Type.Minus));
          break;
        case '*':
          for (int j = tokens.Count - 1; j >= 0; j--)
          {
            if (tokens[j].TokenType == Token.Type.Plus || tokens[j].TokenType == Token.Type.Minus)
              tokens.Insert(j + 1, new Token("(", Token.Type.Lparen));
          }
          if (tokens.Last().TokenType == Token.Type.Integer || tokens.Last().TokenType == Token.Type.Rparen)
            tokens.Add(new Token("*", Token.Type.Asterisk));
          break;
        case '/':
          for (int j = tokens.Count - 1; j >= 0; j--)
          {
            if (tokens[j].TokenType == Token.Type.Plus || tokens[j].TokenType == Token.Type.Minus)
              tokens.Insert(j + 1, new Token("(", Token.Type.Lparen));
          }
          if (tokens.Last().TokenType == Token.Type.Integer || tokens.Last().TokenType == Token.Type.Rparen)
            tokens.Add(new Token("/", Token.Type.Slash));
          break;
        case '%':
          for (int j = tokens.Count - 1; j >= 0; j--)
          {
            if (tokens[j].TokenType == Token.Type.Plus || tokens[j].TokenType == Token.Type.Minus)
              tokens.Insert(j + 1, new Token("(", Token.Type.Lparen));
          }
          if (tokens.Last().TokenType == Token.Type.Integer || tokens.Last().TokenType == Token.Type.Rparen)
            tokens.Add(new Token("%", Token.Type.Percent));
          break;
        case '(':
          tokens.Add(new Token("(", Token.Type.Lparen));
          break;
        case ')':
          tokens.Add(new Token(")", Token.Type.Rparen));
          break;
        default:
          if (!char.IsDigit(expression[i])) break;
          var sb = new StringBuilder(expression[i].ToString());
          for (int j = i + 1; j < expression.Length; j++)
          {
            if (!char.IsDigit(expression[j])) break;
            sb.Append(expression[j]);
            i++;
          }
          tokens.Add(new Token(sb.ToString(), Token.Type.Integer));
          var hasOperator = false;
          for (int j = tokens.Count - 1; j >= 0; j--)
          {
            if (tokens[j].TokenType == Token.Type.Plus || tokens[j].TokenType == Token.Type.Minus)
              break;
            if (tokens[j].TokenType == Token.Type.Asterisk || tokens[j].TokenType == Token.Type.Slash || tokens[j].TokenType == Token.Type.Percent)
              hasOperator = true;
            if (tokens[j].TokenType == Token.Type.Lparen)
            {
              if (hasOperator) tokens.Add(new Token(")", Token.Type.Rparen));
              break;
            }

          }
          break;
      }
    }
    return tokens;
  }
  public int Parser(IReadOnlyList<Token> tokens)
  {
    Operation operation = new Operation();
    bool hasLHS = false;

    for (int i = 0; i < tokens.Count; i++)
    {
      switch (tokens[i].TokenType)
      {
        case Token.Type.Plus:
          operation.OperationType = Operation.Type.Add;
          break;
        case Token.Type.Minus:
          operation.OperationType = Operation.Type.Subtract;
          break;
        case Token.Type.Asterisk:
          operation.OperationType = Operation.Type.Multiply;
          break;
        case Token.Type.Slash:
          operation.OperationType = Operation.Type.Divide;
          break;
        case Token.Type.Percent:
          operation.OperationType = Operation.Type.Module;
          break;
        case Token.Type.Integer:
          var value = int.Parse(tokens[i].Text);
          if (!hasLHS)
          {
            operation.Left = value;
            hasLHS = true;
          }
          else
            operation.Right = value;
          break;
        case Token.Type.Lparen:
          int j = i, cL = 0, cR = 0;
          for (; j < tokens.Count; j++)
          {
            if (tokens[j].TokenType == Token.Type.Rparen && cL == cR) break;
            else if (j > i && tokens[j].TokenType == Token.Type.Lparen)
              cL += 1;
            else if (j > i && tokens[j].TokenType == Token.Type.Rparen)
              cR += 1;
          }
          var subTokens = tokens.Skip(i + 1).Take(j - i - 1).ToList();
          var v = Parser(subTokens);
          if (!hasLHS)
          {
            operation.Left = v;
            hasLHS = true;
          }
          else
            operation.Right = v;
          i = j;
          break;
        default:
          throw new ArgumentNullException();
      }
    }
    return operation.Value;
  }
}

