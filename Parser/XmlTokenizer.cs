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
                        break;
                    case CLOSE: 
                        tokens.Add(new XmlToken { type = XmlToken.TokenType.Close });
                        break;
                    case END:
                        tokens.Add(new XmlToken { type = XmlToken.TokenType.END });
                        break;
                    case QUOTE:
                        break;
                    case SPLIT:
                        FlushBuffer();
                        break;
                    default:
                        buffer.Append(c);
                        break;
                }
            }
        }

        private void FlushBuffer()
        {
            if (buffer.Length <= 0) return;

            tokens.Add(new XmlToken
            {
                type = XmlToken.TokenType.Value,
                value = buffer.ToString()
            });

            buffer.Clear();
        }
    }
}
