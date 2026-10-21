namespace L06;

class CaesarCipher(int key)
{
    private int key = key;

    private string TransformMessage(string message, int key)
    {
        string result = "";
        foreach (char c in message)
        {
            if (char.IsUpper(c))
            {
                result += (char)('A' + ((c - 'A' + key) % 26 + 26) % 26);
            }
            else if (char.IsLower(c))
            {
                result += (char)('a' + ((c - 'a' + key) % 26 + 26) % 26);
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    public string Encode(string message)
    {
        return TransformMessage(message, key);
    }

    public string Decode(string message)
    {
        return TransformMessage(message, -key);
    }
}
