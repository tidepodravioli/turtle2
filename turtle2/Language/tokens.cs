/*
 * Created by SharpDevelop.
 * User: student
 * Date: 2019-04-17
 * Time: 12:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace turtle2.Language
{
	public class TokenDefinition
	{
		private Regex _regex;
	    private readonly TokenType _returnsToken;
	
	    public TokenDefinition(TokenType returnsToken, string regexPattern)
	    {
	        _regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
	        _returnsToken = returnsToken;
	    }
	
	    public TokenMatch Match(string inputString)
	    {
	        var match = _regex.Match(inputString);
	        if (match.Success)
	        {
	            string remainingText = string.Empty;
	            if (match.Length != inputString.Length)
	                remainingText = inputString.Substring(match.Length);
	
	            return new TokenMatch()
	            {
	                IsMatch = true,
	                RemainingText = remainingText,
	                TokenType = _returnsToken,
	                Value = match.Value
	            };
	        }
	        else
	        {
	            return new TokenMatch() { IsMatch = false};
	        }
	
	    }
	}
	
	public class TokenMatch
	{
	    public bool IsMatch { get; set; }
	    public TokenType TokenType { get; set; }
	    public string Value { get; set; }
	    public string RemainingText { get; set; }
	}
	
	public class DslToken
	{
	    public DslToken(TokenType tokenType)
	    {
	        TokenType = tokenType;
	        Value = string.Empty;
	    }
	
	    public DslToken(TokenType tokenType, string value)
	    {
	        TokenType = tokenType;
	        Value = value;
	    }
	
	    public TokenType TokenType { get; set; }
	    public string Value { get; set; }
	
	    public DslToken Clone()
	    {
	        return new DslToken(TokenType, Value);
	        
	    }
	    
	    
	}
	
	public partial class Tokenizer
	{
		private List<TokenDefinition> _tokenDefinitions = new List<TokenDefinition>();
		public Tokenizer()
		{
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Boolean, "^bool)"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.CloseParenthesis, "^\\)"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Comma, "^,"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Console, "^console|^cout)"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Dot, "^."));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Else, "^else)"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Equals, "^="));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Exception, "^ex|^exception"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Message, "^msg|^message"));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.OpenParenthesis, "^\\("));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.StringValue, "^\"[^\"]*\""));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.Number, "^\\d+"));
		}
		
		
		public List<DslToken> Tokenize(string lqlText)
		{
		    var tokens = new List<DslToken>();
		    string remainingText = lqlText;
		
		    while (!string.IsNullOrWhiteSpace(remainingText))
		    {
		        var match = FindMatch(remainingText);
		        if (match.IsMatch)
		        {
		            tokens.Add(new DslToken(match.TokenType, match.Value));
		            remainingText = match.RemainingText;
		        }
		        else
		        {
		            remainingText = remainingText.Substring(1);
		        }
		    }
		
		    tokens.Add(new DslToken(TokenType.SequenceTerminator, string.Empty));
		
		    return tokens;
		}
		
		private TokenMatch FindMatch(string lqlText)
		{
		    foreach (var tokenDefinition in _tokenDefinitions)
		    {
		        var match = tokenDefinition.Match(lqlText);
		        if (match.IsMatch)
		            return match;
		    }
		
		    return new TokenMatch() {  IsMatch = false };
		}
	}
	
	
	
}
	

