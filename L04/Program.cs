namespace L04;

class Program
{
    static void Main(string[] args)
    {
        PrintTaskHeader(1);
        string text = "This is a sample text for counting letters, digits, and vowels.";
        string vowelsList = "aeiouAEIOU";
        uint letters = 0, digits = 0, vowels = 0;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                letters++;
                if (vowelsList.Contains(c)) vowels++;   
            }
            else if (char.IsDigit(c)) digits++;
        }

        Console.WriteLine($"Text: {text}");
        Console.WriteLine($"Letters: {letters}");
        Console.WriteLine($"Digits: {digits}");
        Console.WriteLine($"Vowels: {vowels}");

        PrintTaskHeader(2);
        Console.Write("Adj meg egy szöveget: ");
        string text2 = Console.ReadLine() ?? string.Empty;
        string textWithoutSpaces = text2.Replace(" ", "").ToLower();
        bool isPalindrome = textWithoutSpaces.SequenceEqual(textWithoutSpaces.Reverse());
        Console.WriteLine($"A szöveg {(isPalindrome ? "palindróm" : "nem palindróm")}.");

        PrintTaskHeader(3);
        Console.Write("Adj meg egy rendszámot: ");
        string licensePlate = Console.ReadLine() ?? string.Empty;
        string formatted = "";

        licensePlate = licensePlate.Replace(" ", "").ToUpper();
        for (int i = 0; i < licensePlate.Length; i++)
        {
            formatted += licensePlate[i];
            if (i == 1)
                formatted += " ";
            if (i == 3)
                formatted += "-";
        }

        Console.WriteLine($"\nFormázott rendszám: {formatted}");

        PrintTaskHeader(4);
        Console.WriteLine("5 véletlen generált rendszám:");
        Random random = new();
        
        for (int i = 0; i < 5; i++)
        {
            string randomLicensePlate = "";
            for (int j = 0; j < 2; j++)
            {
                randomLicensePlate += (char)random.Next('A', 'Z' + 1);
            }
            randomLicensePlate += " ";
            for (int j = 0; j < 2; j++)
            {
                randomLicensePlate += (char)random.Next('A', 'Z' + 1);
            }
            randomLicensePlate += "-";
            for (int j = 0; j < 3; j++)
            {
                randomLicensePlate += random.Next(0, 10).ToString();
            }
            Console.WriteLine(randomLicensePlate);
        }

        PrintTaskHeader(5);
        Console.Write("Adj meg egy email címet: ");
        string email = Console.ReadLine() ?? string.Empty;
        bool isValidEmail = true;
        int atIndex = email.IndexOf('@');

        // a) pontosan egy @ karakter
        if (atIndex == -1 || atIndex != email.LastIndexOf('@'))
        {
            isValidEmail = false;
        }
        else
        {
            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);

            // b) legalább egy betű a @ előtt
            bool hasLetterBeforeAt = false;
            foreach (char c in localPart)
            {
                if (char.IsLetter(c))
                    hasLetterBeforeAt = true;
            }
            if (!hasLetterBeforeAt)
                isValidEmail = false;

            // c) legalább egy . a @ után
            int lastDotIndex = domainPart.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                isValidEmail = false;
            }
            else
            {
                // d) a @ és az utolsó . között legalább egy betű vagy szám
                bool hasLetterOrDigit = false;
                for (int i = 0; i < lastDotIndex; i++)
                {
                    if (char.IsLetterOrDigit(domainPart[i]))
                        hasLetterOrDigit = true;
                }
                if (!hasLetterOrDigit)
                    isValidEmail = false;

                // f) az utolsó . után legalább két betű
                int lettersAfterDot = 0;
                for (int i = lastDotIndex + 1; i < domainPart.Length; i++)
                {
                    if (char.IsLetter(domainPart[i]))
                        lettersAfterDot++;
                }
                if (lettersAfterDot < 2)
                    isValidEmail = false;
            }

            // e) a @ előtti . előtt és után is betű vagy szám áll
            for (int i = 0; i < localPart.Length; i++)
            {
                if (localPart[i] == '.')
                {
                    if (i == 0 || i == localPart.Length - 1
                        || !char.IsLetterOrDigit(localPart[i - 1])
                        || !char.IsLetterOrDigit(localPart[i + 1]))
                    {
                        isValidEmail = false;
                    }
                }
            }
        }

        Console.WriteLine($"Az email cím {(isValidEmail ? "helyes" : "helytelen")}.");

        PrintTaskHeader(6);
        string neptunLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string neptunChars = neptunLetters + "0123456789";
        Console.Write("Add meg a Neptun-kódodat: ");
        string ownNeptun = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

        if (ownNeptun.Length != 6 || !char.IsLetter(ownNeptun[0]))
        {
            Console.WriteLine("Érvénytelen Neptun-kód.");
        }
        else
        {
            Console.WriteLine("Keresés folyamatban, ez eltarthat egy ideig...");
            long attempts = 0;
            bool found = false;

            while (!found)
            {
                attempts++;
                found = true;
                // Karakterenként generálunk, és az első eltérésnél abbahagyjuk,
                // mert onnantól a kód már biztosan nem egyezik (így sokkal gyorsabb)
                for (int i = 0; i < 6 && found; i++)
                {
                    char generated = i == 0
                        ? neptunLetters[random.Next(neptunLetters.Length)]
                        : neptunChars[random.Next(neptunChars.Length)];
                    if (generated != ownNeptun[i])
                        found = false;
                }
            }

            Console.WriteLine($"A(z) {attempts}. generált kód egyezett meg a saját kódoddal ({ownNeptun}).");
        }

        PrintTaskHeader(7);
        string spongeInput = "Well, a Big Mac's a Big Mac, but they call it le Big-Mac.";
        string spongeOutput = "";

        foreach (char c in spongeInput)
        {
            if (random.Next(2) == 0)
                spongeOutput += char.ToUpper(c);
            else
                spongeOutput += char.ToLower(c);
        }

        Console.WriteLine($"Bemenet: {spongeInput}");
        Console.WriteLine($"Kimenet: {spongeOutput}");

        PrintTaskHeader(8);
        string s = "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";
        string[] rows = s.Split('\n');
        int columnCount = rows[0].Split(';').Length;
        string[,] table = new string[rows.Length, columnCount];

        for (int i = 0; i < rows.Length; i++)
        {
            string[] cells = rows[i].Split(';');
            for (int j = 0; j < columnCount; j++)
            {
                table[i, j] = j < cells.Length ? cells[j] : "";
            }
        }

        int[] columnWidths = new int[columnCount];
        for (int j = 0; j < columnCount; j++)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                if (table[i, j].Length > columnWidths[j])
                    columnWidths[j] = table[i, j].Length;
            }
        }

        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                Console.Write(table[i, j].PadRight(columnWidths[j] + 2));
            }
            Console.WriteLine();
        }

        PrintTaskHeader(9);
        Console.Write("Adj meg egy zárójel-sorozatot: ");
        string brackets = Console.ReadLine() ?? string.Empty;
        string openings = "([{";
        string closings = ")]}";
        // Verem tömbbel: a még le nem zárt nyitó zárójeleket tároljuk
        char[] stack = new char[brackets.Length];
        int stackSize = 0;
        bool isBalanced = true;

        for (int i = 0; i < brackets.Length && isBalanced; i++)
        {
            char c = brackets[i];
            if (openings.Contains(c))
            {
                stack[stackSize] = c;
                stackSize++;
            }
            else if (closings.Contains(c))
            {
                if (stackSize == 0 || openings.IndexOf(stack[stackSize - 1]) != closings.IndexOf(c))
                {
                    isBalanced = false;
                }
                else
                {
                    stackSize--;
                }
            }
        }

        if (stackSize != 0)
            isBalanced = false;

        Console.WriteLine($"A zárójelezés {(isBalanced ? "szabályos" : "nem szabályos")}.");

        PrintTaskHeader(10);
        Console.WriteLine("Egyszerű szövegszerkesztő: nyilakkal navigálhatsz, Esc-re kilép.");
        Console.WriteLine("Nyomd meg az Enter-t az indításhoz...");
        Console.ReadLine();

        int editorWidth = 50;
        int editorHeight = 20;
        char[,] editor = new char[editorHeight, editorWidth];
        for (int i = 0; i < editorHeight; i++)
        {
            for (int j = 0; j < editorWidth; j++)
            {
                editor[i, j] = ' ';
            }
        }

        int cursorRow = 0, cursorCol = 0;
        bool editing = true;
        string border = "+" + new string('-', editorWidth) + "+";
        Console.Clear();

        while (editing)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(border);
            for (int i = 0; i < editorHeight; i++)
            {
                string line = "";
                for (int j = 0; j < editorWidth; j++)
                {
                    line += editor[i, j];
                }
                Console.WriteLine("|" + line + "|");
            }
            Console.WriteLine(border);
            Console.WriteLine($"Sor: {cursorRow + 1}, Oszlop: {cursorCol + 1}   ");
            Console.SetCursorPosition(cursorCol + 1, cursorRow + 1);

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    editing = false;
                    break;
                case ConsoleKey.UpArrow:
                    if (cursorRow > 0) cursorRow--;
                    break;
                case ConsoleKey.DownArrow:
                    if (cursorRow < editorHeight - 1) cursorRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (cursorCol > 0) cursorCol--;
                    break;
                case ConsoleKey.RightArrow:
                    if (cursorCol < editorWidth - 1) cursorCol++;
                    break;
                case ConsoleKey.Enter:
                    if (cursorRow < editorHeight - 1)
                    {
                        cursorRow++;
                        cursorCol = 0;
                    }
                    break;
                default:
                    if (!char.IsControl(key.KeyChar))
                    {
                        editor[cursorRow, cursorCol] = key.KeyChar;
                        if (cursorCol < editorWidth - 1)
                        {
                            cursorCol++;
                        }
                        else if (cursorRow < editorHeight - 1)
                        {
                            cursorRow++;
                            cursorCol = 0;
                        }
                    }
                    break;
            }
        }

        Console.SetCursorPosition(0, editorHeight + 3);

        PrintTaskHeader(11);
        string base64Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        Console.Write("Adj meg egy kódolandó szöveget: ");
        string toEncode = Console.ReadLine() ?? string.Empty;
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(toEncode);
        string encoded = "";

        for (int i = 0; i < bytes.Length; i += 3)
        {
            // Hány valódi bájt van ebben a 3 bájtos egységben (a végén lehet 1 vagy 2 is)
            int remaining = bytes.Length - i;
            int b0 = bytes[i];
            int b1 = remaining > 1 ? bytes[i + 1] : 0;
            int b2 = remaining > 2 ? bytes[i + 2] : 0;

            // 3 bájt = 24 bit
            int chunk = (b0 << 16) | (b1 << 8) | b2;

            // 24 bit = 4 darab 6 bites szegmens
            encoded += base64Alphabet[(chunk >> 18) & 63];
            encoded += base64Alphabet[(chunk >> 12) & 63];
            encoded += remaining > 1 ? base64Alphabet[(chunk >> 6) & 63] : '=';
            encoded += remaining > 2 ? base64Alphabet[chunk & 63] : '=';
        }

        Console.WriteLine($"Kódolt szöveg:   {encoded}");
        Console.WriteLine($"Ellenőrzés (.NET): {Convert.ToBase64String(bytes)}");

        Console.WriteLine("\n\nNyomd meg az Enter-t a kilépéshez...");
        Console.ReadLine();
    }

    static void PrintTaskHeader(int taskNumber)
    {
        Console.WriteLine($"\n--- {taskNumber}. feladat ---\n");
    }
}
