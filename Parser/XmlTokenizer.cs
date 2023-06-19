using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlChecker.Parser
{
    public struct XmlToken
    {
        public enum TokenType
        {
            Open,
            Close,
            End,
            Symbol,
            Quote,
            Split,
            Undefined,
        }

        public TokenType type;
        public string value;

        public XmlToken()
        {
            type = TokenType.Undefined;
            value = string.Empty;
        }
    }

    public class XmlTokenizer
    {
        const char OPEN = '<';
        const char CLOSE = '>';
        const char END = '/';
        const char SPLIT = ' ';
        const char QUOTE = '"';

        const char ALPHA = 'A';
        const char ZETA = 'z';
        private List<XmlToken> tokens = new();
        public List<XmlToken> Tokens => tokens;

        private StringBuilder buffer = new();

        public XmlTokenizer(string source) 
        {
            foreach(var c in source) 
            {
                switch(c)
                {
                    case OPEN: 
                        tokens.Add(new XmlToken { type = XmlToken.TokenType.Open });
                        FlushBuffer();
                        break;
                    case CLOSE: 
                        tokens.Add(new XmlToken { type = XmlToken.TokenType.Close });
                        FlushBuffer();
                        break;
                    case END:
                        tokens.Add(new XmlToken { type = XmlToken.TokenType.End });
                        FlushBuffer();
                        break;
                    case QUOTE:
                        FlushBuffer();
                        break;
                    case SPLIT:
                        FlushBuffer();
                        break;
                    case char uper when 'A' <= uper && uper <= 'Z':
                    case char down when 'a' <= down && down <= 'z':
                        buffer.Append(c);
                        break;
                }
            }
        }

        //public void PrintTokens() => foreach
        
        private void FlushBuffer()
        {
            if (buffer.Length <= 0) return;

            tokens.Add(new XmlToken
            {
                type = XmlToken.TokenType.Symbol,
                value = buffer.ToString()
            });

            buffer.Clear();
        }
    }
}
