namespace AdventOfCode
{
    public abstract class AbstractBaseDay : BaseDay
    {
        protected readonly string _inputText;
        protected readonly string[] _inputLines;
        protected AbstractBaseDay()
        {
            _inputText = File.ReadAllText(InputFilePath);
            _inputLines = _inputText.Split("\r\n");
        }
    }
}
