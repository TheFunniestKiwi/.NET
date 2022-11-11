namespace api
{
    public class Censor
    {
        /// <summary>
        /// Lista słów, które mają zostać ocenzurowane w tekście
        /// </summary>
        public List<string> Blacklist { get; set; } = new List<string>();

        /// <summary>
        /// Funkcja cenzurująca pojedyncze słowo.
        /// 
        /// Słowa, które znajdują się na liście <see cref="Blacklist"/> mają zostać zamienione
        /// na pierwszą literę oraz taką liczbę gwiazdek, ile miało oryginalne słowo,
        /// np. "bomba" na "b****"
        /// </summary>
        /// <param name="word">Słowo nieocenzurowane</param>
        /// <returns>Słowo ocenzurowane</returns>
        public string CensorWord(string word)
        {
            if (Blacklist.Contains(word.ToLower()))
            {
                char[] result = word.ToCharArray();
                for (int i = 1; i < word.Length; i++)
                {
                    result[i] = '*';
                }
                return new string(result);
            }

            return word;
        }

        /// <summary>
        /// Funkcja cenzurująca cały tekst, który możę się składać z wielu słów.
        /// 
        /// Można zignorować znaki przestankowe (,."?! itp.) oraz nadmiarowe spacje w środku tekstu.
        /// </summary>
        /// <param name="text">Tekst nieocenzurowany</param>
        /// <returns>Tekst ocenzurowany</returns>
        public string CensorText(string text)
        {
            List<string> list = text.Split(new char[] {' '}).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = CensorWord(list[i]);
            }
            return string.Join(" ", list);
        }
    }
}
